using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipType
    {
        public enum ValidMemberhipType
        {
            Unknow = 0,
            PayAsYouGo = 1,
            Monthly = 2,
            Quarterly = 3,
            Annual = 4
        }

        [Key]
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationInMonths{ get; set; }
        public byte DiscountRates { get; set; }

        public static readonly int Unknow = 0;
        public static readonly int PayAsYouGo = 1;
    }
}