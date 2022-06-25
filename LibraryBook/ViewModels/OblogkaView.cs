using LibraryBook.Models;
namespace LibraryBook.ViewModels
{
    public class OblogkaView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public List<Genre> Genres{ get; set; }
        public uint Page { get; set; }
    }
}
