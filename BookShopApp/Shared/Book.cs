using MongoDB.Bson;

namespace BookShopApp.Shared
{
    public class Book
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        public string ReleaseYear { get; set; }
        public int PagesNumber { get; set; }
        public int AgeRestriction { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
    }
}
