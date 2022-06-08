namespace LibraryBook.Models
{
    public class RateBook
    {
        public int idRate { get; set; }
        public int idBook { get; set; }
        public int idUser { get; set; }
        public Rate? Rates { get; set; }
        public Book? Books { get; set; }
        public User? Users { get; set; }
    } 
}
