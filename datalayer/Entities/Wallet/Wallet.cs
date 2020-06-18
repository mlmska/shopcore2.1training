using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace datalayer.Entities.Wallet
{
    public class Wallet
    {

        public Wallet()
        {

        }

        [Key]
        public int WalletID { get; set; }


        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TypeID { get; set; }

        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserID { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "تایید شده")]
        public bool isPay { get; set; }

        [Display(Name = "توضیح")]
        [MaxLength(500, ErrorMessage = "{0} نمتواند بیشتر از {1} کاراکتر داشته باشد ")]
        public string Description { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime Createdate { get; set; }



        #region Relation

        public virtual User.User User { get; set; }

        public virtual WalletType WalletType { get; set; }


        #endregion


    }
}
