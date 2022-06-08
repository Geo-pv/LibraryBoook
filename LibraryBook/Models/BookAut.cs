namespace LibraryBook.Models
{
    public class BookAut
    {
        public int idAuthor { get; set; }
        public int idBook { get; set; }
        public Author? Authors { get; set; }
        public Book? Books { get; set; }
    }
}
