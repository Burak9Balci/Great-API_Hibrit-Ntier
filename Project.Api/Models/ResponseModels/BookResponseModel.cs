namespace Project.Api.Models.ResponseModels
{
    public class BookResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitInStock { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public short? BookShelf { get; set; }
        public string EditorName { get; set; }
    }
}
