using System;
using System.Collections.Generic;
using System.Text;
using Core.DTOs;
using datalayer.Entities.User;
using datalayer.Entities.Wallet;

namespace Core.Services.Intefaces
{
   public interface IUserService
    {
        bool isExistUserName(string userName);
        bool isExistEmail(string email);
        int adduser(User user);
        User Loginuser(LoginViewModel login);
        User getuserbyemail(string email);
        User getuserbyid(int userid);
        User getuserbyactivecode(string activecode);
        User getuserbyusername(string username);
        void updateuser(User user);
        void Deleteuser(int userid);
        bool ActiveAccount(string activecode);

        #region Userpanel

        InformationViewModel getuserinformation(string username);

        InformationViewModel getuserinformation(int userid);

        SidebarUserpanelViewModel getsidebarinfo(string username);

        EditprofileViewModel getdataforeditprofile(string username);

        void Editprofile(string username,EditprofileViewModel edit);

        bool CompareOldepassword(string oldpassword, string username);

        void Changepassword(string username, string newpassword);

        int getuseridbyusername(string username);

        #endregion
        #region wallet

        int Balanceuserwallett(string username);

        List<WalletViewModel> getuserwallet(string username);

        int Chargewallet(string username, int amount,string description, bool ispay=false);

        int addwallet(Wallet wallet);

        Wallet getwalletbywalletid(int walletid);

        void updatewallet(Wallet wallet);
        #endregion
        #region admin panel
        UserForAdminViewModel getusers(int pageid = 1, string filteremail = "", string filteruserName = "");  
        UserForAdminViewModel getdeletedusers(int pageid = 1, string filteremail = "", string filteruserName = "");
        int adduserfromadmin(CreateUserViewModel create);

        EditUserViewModel getuserforshowinedit(int userid);

        void edituserfromadmin(EditUserViewModel edit);
        #endregion

    }
}
