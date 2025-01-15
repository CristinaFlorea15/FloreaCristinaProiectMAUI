using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using FloreaCristinaProiect.Models;

namespace FloreaCristinaProiect.Data
{
    public class PastriesListDataBase
    {
        readonly SQLiteAsyncConnection _database;
        public PastriesListDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<PastriesList>().Wait();
            _database.CreateTableAsync<ShoppingCartItem>().Wait(); // Ensure ShoppingCartItem table exists
            _database.CreateTableAsync<Review>().Wait();
        }

        public Task<List<PastriesList>> GetPastriesListsAsync()
        {
            return _database.Table<PastriesList>().ToListAsync();
        }

        public Task<PastriesList> GetPastriesListAsync(int id)
        {
            return _database.Table<PastriesList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SavePastriesListAsync(PastriesList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }

        public Task<int> DeletePastriesListAsync(PastriesList slist)
        {
            return _database.DeleteAsync(slist);
        }

        public Task AddToCartAsync(ShoppingCartItem item)
        {
            return _database.InsertAsync(item);
        }

        public Task<List<ShoppingCartItem>> GetCartItemsAsync()
        {
            return _database.Table<ShoppingCartItem>().ToListAsync();
        }

        public Task<int> UpdateCartItemAsync(ShoppingCartItem item)
        {
            return _database.UpdateAsync(item);
        }

        public Task<int> RemoveFromCartAsync(ShoppingCartItem item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<int> ClearCartAsync()
        {
            return _database.DeleteAllAsync<ShoppingCartItem>();
        }

        public Task<List<Review>> GetReviewsAsync()
        {
            return _database.Table<Review>().ToListAsync();
        }

        public Task<int> SaveReviewAsync(Review review)
        {
            return review.ID != 0
                ? _database.UpdateAsync(review)
                : _database.InsertAsync(review);
        }

        public Task<int> DeleteReviewAsync(Review review)
        {
            return _database.DeleteAsync(review);
        }

    }
}

