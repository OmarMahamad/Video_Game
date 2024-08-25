using System.ComponentModel.DataAnnotations;

namespace Video_Game.Models
{
    public class Gamer:User
    {
        [Key]
        public int GamerID { get; set; }

        public string? SubscriptionType { get; set; }



        // one to one
        public Subscription? Subscription { get; set; }
        public int? SubscriptionId { get; set; }

        // many
        public ICollection<Order>? Orders { get; set;}
        public ICollection<Games>? Games { get; set; }



    }
}
