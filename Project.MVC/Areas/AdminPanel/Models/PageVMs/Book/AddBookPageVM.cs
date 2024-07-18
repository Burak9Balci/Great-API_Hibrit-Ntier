using Project.VM.Models;

namespace Project.MVC.Areas.AdminPanel.Models.PageVMs.Book
{
    public class AddBookPageVM
    {
        public BookVM Book { get; set; }
        public List<AuthorVM> Authors { get; set; }
        public List<CategoryVM> Categories { get; set; }
        public List<BookShelfVM> BookShelves { get; set; }
        public List<EditorVM> Editors { get; set; }
    }
}
