using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace mugonnanpadx.Models
{
    public class MugonMessage
    {
        public int ID { get; set; }
        [Display(Name = "メッセージ")]
        public string Message { get; set; }

        [Display(Name = "Yes数")]
        public int Yes { get; set; }

        [Display(Name = "No数")]
        public int No { get; set; }

        [Display(Name = "UserID")]
        public string UserID { get; set; }

    }

    public class MugonDBContext : DbContext
    {
        public DbSet<MugonMessage> MugonMessages { get; set; }
    }
}