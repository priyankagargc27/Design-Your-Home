using System.ComponentModel.DataAnnotations;


namespace DesignYourHome.Models
{
    public class Room
    {
        [Required]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Key]
        public int RoomId { get; set; }

        [Required]
        public string Name { get; set; }
        //[Required]
        // public string Image { get; set; }
        [Required]
        public string Design { get; set; }

    }
}