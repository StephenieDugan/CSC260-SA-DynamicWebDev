using System.ComponentModel.DataAnnotations;

namespace GameModelStuff.Models
{
    public class MovieMini
    {
        public int? Id { get; set; } //= nextID++;

        public string? Title { get; set; }
        public string? Platform { get; set; }

        public string? Genre { get; set; }
        public string? Rating { get; set; }

        public int? Year { get; set; }


        public MovieMini() { }


    }
}
