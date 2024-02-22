namespace GameModelStuff.Models
{
    public class GameAndUser
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public int? Year { get; set; }
        public string? Platform { get; set; }
        public string? Rating { get; set; }
        public string? Genre { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }

        public GameAndUser() { }
    }
}
