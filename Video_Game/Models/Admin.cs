using System.ComponentModel.DataAnnotations;

namespace Video_Game.Models
{
    public class Admin:User
    {
        [Key]
        public int AdminID { get; set; }

        //

    }
}
