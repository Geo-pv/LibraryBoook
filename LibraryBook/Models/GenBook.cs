namespace LibraryBook.Models
{
    public class GenBook
    {
        public int idGenre { get; set; }
        public int idBook { get; set; }
        public Genre? Genres { get; set; }
        public Book? Books { get; set; }
    }
}
