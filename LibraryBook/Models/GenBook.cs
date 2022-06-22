namespace LibraryBook.Models
{
    public class GenBook
    {
        public int GenreId { get; set; }
        public int BookId { get; set; }
        public Genre? Genres { get; set; }
        public Book? Books { get; set; }
    }
}
