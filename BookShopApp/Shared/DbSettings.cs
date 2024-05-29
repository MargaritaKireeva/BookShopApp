using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopApp.Shared
{

    public class DbSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DbName { get; set; } = null!;

        public string BooksCollectionName { get; set; } = null!;
        public string GenresCollectionName { get; set; } = null!;
        public string FeedbackCollectionName { get; set; } = null!;
    }
}
