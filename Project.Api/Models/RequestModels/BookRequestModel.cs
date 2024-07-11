namespace Project.Api.Models.RequestModels
{
    public class BookRequestModel
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string AuthorName { get; set; }
        public short ShelfNo { get; set; }
        public string CategoryName { get; set; }
        public string EditorName { get; set; }
    }
}
