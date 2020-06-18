using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core.Convertors;
using Core.DTOs;
using Core.Generator;
using Core.Security;
using Core.Services.Intefaces;
using datalayer.Context;
using datalayer.Entities.User;
using datalayer.Entities.Wallet;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class Userservice : IUserService
    {
        private Corecontext _db;

        public Userservice(Corecontext db)
        {
            _db = db;
        }

        public bool ActiveAccount(string activecode)
        {
            var user = _db.Users.SingleOrDefault(p => p.Activecode == activecode);
            if (user == null || user.isActive)
            {
                return false;
            }
            user.isActive = true;
            user.Activecode = Namegenerator.GenerateUniqcode();
            _db.SaveChanges();
            return true;
        }

        public int adduser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.UserID;
        }

        public int adduserfromadmin(CreateUserViewModel create)
        {
            User aduser = new User();
            aduser.Password = PasswordHelper.EncodePasswordMd5(create.Password);
            aduser.Activecode = Namegenerator.GenerateUniqcode();
            aduser.Email = create.Email;
            aduser.isActive = true;
            aduser.Registerdate = DateTime.Now;
            aduser.UserName = create.UserName;
            #region useravatar
            if (create.UserAvatar != null)
            {
                string Imagepath = "";
                aduser.UserAvatar = Namegenerator.GenerateUniqcode() + Path.GetExtension(create.UserAvatar.FileName);
                Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", aduser.UserAvatar);
                using (var stream = new FileStream(Imagepath, FileMode.Create))
                {
                    create.UserAvatar.CopyTo(stream);
                }
            }
            #endregion
            return adduser(aduser);

        }

        public int addwallet(Wallet wallet)
        {
            _db.Wallets.Add(wallet);
            _db.SaveChanges();
            return wallet.WalletID;
        }

        public int Balanceuserwallett(string username)
        {
            int userid = getuseridbyusername(username);

            var deposit = _db.Wallets.Where(p => p.UserID == userid && p.TypeID == 1&&p.isPay).Select(p => p.Amount).ToList();
            var Withdraw = _db.Wallets.Where(p => p.UserID == userid && p.TypeID == 2).Select(p => p.Amount).ToList();

            return (deposit.Sum() - Withdraw.Sum());

        }

        public void Changepassword(string username, string newpassword)
        {
            var user = getuserbyusername(username);
            user.Password = PasswordHelper.EncodePasswordMd5(newpassword);
            updateuser(user);
        }

       

        public int Chargewallet(string username, int amount, string description, bool ispay = false)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                Description = description,
                Createdate = DateTime.Now,
                isPay = ispay,
                TypeID = 1,
                UserID = getuseridbyusername(username)
            };
            return addwallet(wallet);
        }

        public bool CompareOldepassword(string oldpassword, string username)
        {
            string oldhashpassword = PasswordHelper.EncodePasswordMd5(oldpassword);
            return _db.Users.Any(p => p.UserName == username && p.Password == oldhashpassword);
        }

        public void Deleteuser(int userid)
        {
            User user = getuserbyid(userid);
            user.isDelete = true;
            updateuser(user);
        }

        public void Editprofile(string username,EditprofileViewModel edit)
        {
            if (edit.UserAvatar != null)
            {
                string Imagepath = ""; 
                if (edit.AvatarName != "Deafault.jpg")
                {
                    Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", edit.AvatarName);
                    if (File.Exists(Imagepath))
                    {
                        File.Delete(Imagepath);
                    }
                }
                edit.AvatarName= Namegenerator.GenerateUniqcode() + Path.GetExtension(edit.UserAvatar.FileName);
                Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar",edit.AvatarName);
                using (var stream=new FileStream(Imagepath,FileMode.Create))
                {
                    edit.UserAvatar.CopyTo(stream);
                }
            }
            var user = getuserbyusername(username);
            user.UserName = edit.UserName;
            user.Email = edit.Email;
            user.UserAvatar = edit.AvatarName;

            updateuser(user);


        }

        public void edituserfromadmin(EditUserViewModel edit)
        {
            User user = getuserbyid(edit.UserID);
            user.Email = edit.Email;
            if (!string.IsNullOrEmpty(edit.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(edit.Password);
            }
        
            if (edit.UserAvatar != null)
            {
                if (edit.AvatarName != "Deafault.jpg")
                {
                   string dImagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", edit.AvatarName);
                    if (File.Exists(dImagepath))
                    {
                        File.Delete(dImagepath);
                    }
                }
                user.UserAvatar = Namegenerator.GenerateUniqcode() + Path.GetExtension(edit.UserAvatar.FileName);
               string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatar);
                using (var stream = new FileStream(Imagepath, FileMode.Create))
                {
                    edit.UserAvatar.CopyTo(stream);
                }
            }
            _db.Users.Update(user);
            _db.SaveChanges();
            
        }

        public EditprofileViewModel getdataforeditprofile(string username)
        {
            return _db.Users.Where(p => p.UserName == username).Select(p => new EditprofileViewModel()
            {
                Email=p.Email,
                UserName=p.UserName,
                AvatarName=p.UserAvatar

            }).Single();
        }

        public UserForAdminViewModel getdeletedusers(int pageid = 1, string filteremail = "", string filteruserName = "")
        {
            IQueryable<User> results = _db.Users.IgnoreQueryFilters().Where(u => u.isDelete);

            if (!string.IsNullOrEmpty(filteremail))
            {
                results = results.Where(u => u.Email.Contains(filteremail));
            }
            if (!string.IsNullOrEmpty(filteruserName))
            {
                results = results.Where(u => u.UserName.Contains(filteruserName));
            }

            int take = 20;
            int skip = (pageid - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();
            list.CurrentPage = pageid;
            list.PageCount = results.Count() / take;
            list.users = results.OrderBy(u => u.Registerdate).Skip(skip).Take(take).ToList();



            return list;
        }

        public SidebarUserpanelViewModel getsidebarinfo(string username)
        {
            return _db.Users.Where(p => p.UserName == username).Select(p=> new SidebarUserpanelViewModel()
            {
                Imagename=p.UserAvatar,
                Registerdate=p.Registerdate,
                UserName=p.UserName
            }).Single();
        }

        public User getuserbyactivecode(string activecode)
        {
            return _db.Users.SingleOrDefault(p => p.Activecode == activecode);
        }

        public User getuserbyemail(string email)
        {
            return _db.Users.SingleOrDefault(u => u.Email == email);
        }

        public User getuserbyid(int userid)
        {
            return _db.Users.Find(userid);
        }

        public User getuserbyusername(string username)
        {
            return _db.Users.SingleOrDefault(p => p.UserName == username);
        }

        public EditUserViewModel getuserforshowinedit(int userid)
        {
            return _db.Users.Where(p => p.UserID == userid).Select(p => new EditUserViewModel()
            {
                UserID=p.UserID,
                AvatarName=p.UserAvatar,
                Email=p.Email,
                UserName=p.UserName,
                UserRoles=p.user_Roles.Select(r=>r.RoleID).ToList()
            }).Single();
        }

        public int getuseridbyusername(string username)
        {
            return _db.Users.Single(p => p.UserName == username).UserID;
        }

        public InformationViewModel getuserinformation(string username)
        {
            var user = getuserbyusername(username);
            InformationViewModel information = new InformationViewModel();
            information.Email = user.Email;
            information.UserName = user.UserName;
            information.Registerdate = user.Registerdate;
            information.Wallet = Balanceuserwallett(username);
            return information;

        }

        public InformationViewModel getuserinformation(int userid)
        {
            var user = getuserbyid(userid);
            InformationViewModel information = new InformationViewModel();
            information.Email = user.Email;
            information.UserName = user.UserName;
            information.Registerdate = user.Registerdate;
            information.Wallet = Balanceuserwallett(user.UserName);
            return information;
        }

        public UserForAdminViewModel getusers(int pageid = 1, string filteremail = "", string filteruserName = "")
        {
            IQueryable<User> results = _db.Users;

            if (!string.IsNullOrEmpty(filteremail))
            {
                results = results.Where(u => u.Email.Contains(filteremail));
            }
            if (!string.IsNullOrEmpty(filteruserName))
            {
                results = results.Where(u => u.UserName.Contains(filteruserName));
            }

            int take = 20;
            int skip = (pageid - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();
            list.CurrentPage = pageid;
            list.PageCount = results.Count() / take;
            list.users = results.OrderBy(u => u.Registerdate).Skip(skip).Take(take).ToList();



            return list;
        }

        public List<WalletViewModel> getuserwallet(string username)
        {
            int userid = getuseridbyusername(username);

            return _db.Wallets.Where(p => p.isPay && p.UserID == userid).Select(p => new WalletViewModel()
            {
                Amount=p.Amount,
                DateTime=p.Createdate,
                Description=p.Description,
                Type=p.TypeID

            }).ToList();
        }

        public Wallet getwalletbywalletid(int walletid)
        {
          return _db.Wallets.Find(walletid);
        }

        public bool isExistEmail(string email)
        {
            return _db.Users.Any(p => p.Email == email);
        }

        public bool isExistUserName(string userName)
        {
            return _db.Users.Any(p => p.UserName == userName);
        }

        public User Loginuser(LoginViewModel login)
        {
            string hashpassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.Fixemail(login.Email);
            return _db.Users.SingleOrDefault(p => p.Email == email && p.Password == hashpassword);
        }

        public void updateuser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void updatewallet(Wallet wallet)
        {
            _db.Wallets.Update(wallet);
            _db.SaveChanges();
        }
    }
}
