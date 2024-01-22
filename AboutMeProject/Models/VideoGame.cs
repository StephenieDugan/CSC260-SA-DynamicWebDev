namespace AboutMeProject.Models
{
    public class VideoGame
    {
        static int nextID = 0;
        public int? Id { get; set; } = nextID++;
        public string? Title { get; set; }
        public int? Year { get; set; }
        public float? Rating { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public String Image { get; set; }

        //always need empty constructor
        public VideoGame() { }

        public VideoGame(string title, int year, float rating, String image)
        {
            this.Title = title;
            this.Year = year;
            this.Rating = rating;
            this.Image = image;
        }
    }
}

