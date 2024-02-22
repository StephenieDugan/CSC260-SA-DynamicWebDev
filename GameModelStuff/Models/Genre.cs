using System.ComponentModel.DataAnnotations;



namespace VideoGameDAL_DI.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }



    }
}
