using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShopApp.Shared;

namespace BookShopApp.DAL.Interfaces
{
    public interface IGenresDAL
    {
        public Task<List<Genre>> GetAllAsync();
    }
}
