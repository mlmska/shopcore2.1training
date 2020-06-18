﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
   public class ChargeViewModel
    {
        [Display(Name ="مبلغ")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

    }
    public class WalletViewModel
    {
        public int Amount { get; set; }

        public int Type { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

    }

}
