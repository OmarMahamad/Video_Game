namespace Video_Game.Models
{
    public class Subscription
    {
        public int SubscriptionID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndtDate { get; set; }



        //one to one 
        public Gamer Gamer { get; set; }
    }
}
