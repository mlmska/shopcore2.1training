using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.User
{
    public class User_Role
    {

        public User_Role()
        {

        }

        [Key]
        public int Us_ID { get; set; }

        public int UserID { get; set; }

        public int RoleID { get; set; }


        #region relation

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }


        #endregion
    }
}
