using System.ComponentModel.DataAnnotations;

namespace LAB4_1
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? RelaseDate { get; set; }

    }
    public class Review
    {
        public string username { get; set; }
        public int Movie_id { get; set; }
        public float Rating { get; set; }

    }

}
