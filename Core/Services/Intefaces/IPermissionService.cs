using datalayer.Entities.Permission;
using datalayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Intefaces
{
    public interface IPermissionService
    {
        #region role

        List<Role> getroles();


        int Addrole(Role role);

        Role GetRolebyid(int roleid);

        void Updaterole(Role role);

        void Deleterole(Role role);

        void Addrolestouser(List<int> roleid, int userid);

        void Editrolesuser(int userid, List<int> roleid);
        #endregion

        #region permission

        List<Permission> Getallpermissions();

        void AddPermissiontoRole(int roleid, List<int> permission);

        List<int> Permissionrole(int roleid);

        void UpdatepermissionRole(int roleid, List<int> permission);

        bool checkpermission(int permissionid, string username);

        #endregion

    }
}
