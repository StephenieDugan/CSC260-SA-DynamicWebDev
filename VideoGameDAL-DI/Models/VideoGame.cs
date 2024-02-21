using VideoGameDAL.Validators;
using System.ComponentModel.DataAnnotations;

namespace VideoGameDAL.Models
{
    [EightiesGameRatings]
    public class VideoGame
    {
        //static int nextID = 0;
        [Key] // primary key
        public int? Id { get; set; } //= nextID++;
        
        [MaxLength(450)]
        public String? UserID { get; set; }

        [Required(ErrorMessage ="Title is required dummy")]
        [MaxLength(214)]
        public string? Title { get; set; }
        public string? Platform { get; set; }
       
        [Required]
        public string? Genre { get; set; }
      
        //public int? genreID {get; set;}
        //public Genre? Genre {get; set;}

        //[Range(1,5, ErrorMessage ="Rating must be between 1 and 5")]
        public string? Rating { get; set; }

        [Required]
        public int? Year { get; set; }

        //[Required]
        public String Image { get; set; }
        public string? LoanedTo { get; set; }
        public DateTime? LoanDate { get; set; }

        //always need empty constructor
        public VideoGame() { }

        public VideoGame(string title,string platform, string genre, string rating, int year, String image)
        {
            this.Title = title;
            this.Platform = platform;
            this.Genre = genre;
            this.Year = year;
            this.Rating = rating;
            this.Image = image;
        }
    }
}

