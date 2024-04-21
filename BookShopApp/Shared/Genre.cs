using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace BookShopApp.Shared
{
    public class Genre
    {
        public ObjectId _id { get; set; }
        public string Title { get; set; }
    }
}
