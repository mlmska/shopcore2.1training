using datalayer.Entities.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.User
{
    public class Role
    {


        public Role()
        {

        }

        [Key]
        public int RoleID { get; set; }


        [Display(Name ="عنوان نقش")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage ="{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public String RoleTilte { get; set; }

        public bool isDelete { get; set; }



        #region relation

        public virtual List<User_Role> user_Roles { get; set; }

        public List<RolePermission> RolePermissions { get; set; }



        #endregion

    }
}
