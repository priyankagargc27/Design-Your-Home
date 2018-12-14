using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignYourHome.Models
{
    public class FixHome
    {
        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Key]
        public int FixHomeId { get; set; }

        [Required]
        public int ContractorId { get; set; }

        [Required]
        public int RoomId { get; set; }

        public virtual Contractor Contractor { get; set; }

        public virtual Room Room { get; set; }

        public string Description { get; set; }
    }
}