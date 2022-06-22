namespace LibraryBook.Models
{
    public class RateBook
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Book? Books { get; set; }
        public User? Users { get; set; }
        public float ? Rate { get; set; }   
    } 
}
