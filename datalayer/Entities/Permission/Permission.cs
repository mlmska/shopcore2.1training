using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace datalayer.Entities.Permission
{
    public class Permission
    {
        [Key]
        public int PermissionID { get; set; }


        [Display(Name = "عنوان دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string PermissionTitle { get; set; }

        public int? ParentID { get; set; }


        [ForeignKey("ParentID")]
        public List<Permission> Permissions { get; set; }

        public List<RolePermission> RolePermissions { get; set; }


    }
}
