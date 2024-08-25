using System.ComponentModel.DataAnnotations;

namespace Video_Game.Models
{
    public class Games
    {
        [Key]
        public int GameID { get; set; }
        public string Titel { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public float Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }

        //
        public Gamer? Gamer { get; set; }

        //
        public ICollection<Order>? Orders { get; set; }

    }
}
