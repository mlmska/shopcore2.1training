using Core.Services.Intefaces;
using datalayer.Context;
using datalayer.Entities.Permission;
using datalayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services
{
    public class PermissionService : IPermissionService
    {
        private Corecontext _db;

        public PermissionService(Corecontext db)
        {
            _db = db;
        }

        public void AddPermissiontoRole(int roleid, List<int> permission)
        {
            foreach(var p in permission)
            {
                _db.RolePermission.Add(new RolePermission()
                {
                    PermissionID = p,
                    RoleID = roleid
                });
            }
            _db.SaveChanges(); 
        }

        public int Addrole(Role role)
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return role.RoleID;
        }

        public void Addrolestouser(List<int> roleid, int userid)
        {
           foreach(var roleID in roleid)
            {
                _db.User_Roles.Add(new User_Role()
                {
                    RoleID=roleID,
                    UserID=userid,
                    
                });
            }
            _db.SaveChanges();
           
        }

        public bool checkpermission(int permissionid, string username)
        {
            int userid = _db.Users.Single(p => p.UserName == username).UserID;

            List<int> userroles = _db.User_Roles.Where(p => p.UserID == userid).Select(p => p.RoleID).ToList();

            if (!userroles.Any())
            {
                return false;
            }

            List<int> Rolepermission = _db.RolePermission.Where(p => p.PermissionID == permissionid).Select(p => p.RoleID).ToList();

            return Rolepermission.Any(p => userroles.Contains(p));

        }

        public void Deleterole(Role role)
        {
            role.isDelete = true;
            Updaterole(role);
        }

        public void Editrolesuser(int userid, List<int> roleid)
        {
            _db.User_Roles.Where(p => p.UserID == userid).ToList().ForEach(p => _db.User_Roles.Remove(p));
            Addrolestouser(roleid, userid);

        }

        public List<Permission> Getallpermissions()
        {
           return _db.Permission.ToList();
        }

        public Role GetRolebyid(int roleid)
        {
            return _db.Roles.Find(roleid);
        }

        public List<Role> getroles()
        {
            return _db.Roles.ToList();
        }

        public List<int> Permissionrole(int roleid)
        {
            return _db.RolePermission.Where(r => r.RoleID == roleid).Select(r => r.PermissionID).ToList();
        }

        public void UpdatepermissionRole(int roleid, List<int> permission)
        {
            _db.RolePermission.Where(p => p.RoleID == roleid).ToList().ForEach(p => _db.RolePermission.Remove(p));
            AddPermissiontoRole(roleid, permission);

        }

        public void Updaterole(Role role)
        {
            _db.Roles.Update(role);
            _db.SaveChanges();
        }
    }
}
