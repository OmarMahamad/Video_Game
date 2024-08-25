using System.ComponentModel.DataAnnotations;

namespace Video_Game.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }



        // one to many
        public Gamer Gamer { get; set; }

        public ICollection<Games> Games { get; set;}
    }
}
