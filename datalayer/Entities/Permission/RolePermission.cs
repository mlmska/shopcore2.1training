using datalayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.Permission
{
    public class RolePermission
    {

        [Key]
        public int RP_ID { get; set; }

        public int RoleID { get; set; }

        public int PermissionID { get; set; }

        public Role Role { get; set; }

        public Permission Permission { get; set; }




    }
}
