using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookShopApp.Shared
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Amount { get; set; }
        public int ReleaseYear { get; set; }
        public int PagesNumber { get; set; }
        public int AgeRestriction { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string GenreId { get; set; }

/*        public Book(ObjectId id, string title, string author, int amount, string releaseYear, int pagesNumber, int ageRestriction, string description, string picture, decimal price, string genre)
        {
            _id = id;
            Title = title;
            Author = author;
            Amount = amount;
            ReleaseYear = releaseYear;
            PagesNumber = pagesNumber;
            AgeRestriction = ageRestriction;
            Description = description;
            Picture = picture;
            Price = price;
            Genre = genre;
        }

        public Book() { }*/
    }
}
