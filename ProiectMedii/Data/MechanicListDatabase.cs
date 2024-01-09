using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProiectMedii.Models;
using ProiectMedii.Data;
using Microsoft.Maui;


namespace ProiectMedii.Data
{
    public class MechanicListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public MechanicListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MechanicList>().Wait();
            _database.CreateTableAsync<Tool>().Wait();
            _database.CreateTableAsync<ListTool>().Wait();
            _database.CreateTableAsync<Mechanic>().Wait();

        }

        public Task<int> SaveProductAsync(Tool tool)
        {
            if (tool.ID != 0)
            {
                return _database.UpdateAsync(tool);
            }
            else
            {
                return _database.InsertAsync(tool);
            }
        }
        public Task<int> DeleteProductAsync(Tool tool)
        {
            return _database.DeleteAsync(tool);
        }
        public Task<List<Tool>> GetProductsAsync()
        {
            return _database.Table<Tool>().ToListAsync();
        }


        public Task<List<MechanicList>> GetShopListsAsync()
        {
            return _database.Table<MechanicList>().ToListAsync();
        }
        public Task<MechanicList> GetShopListAsync(int id)
        {
            return _database.Table<MechanicList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(MechanicList newlist)
        {
            if (newlist.ID != 0)
            {
                return _database.UpdateAsync(newlist);
            }
            else
            {
                return _database.InsertAsync(newlist);
            }
        }
        public Task<int> DeleteShopListAsync(MechanicList newlist)
        {
            return _database.DeleteAsync(newlist);
        }

        public Task<int> SaveListProductAsync(ListTool listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Tool>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Tool>(
            "select P.ID, P.Description from Tool P"
            + " inner join ListTool LP"
            + " on P.ID = LP.ToolID where LP.MechanicListID = ?",
            shoplistid);
        }

        public Task<List<Mechanic>> GetShopsAsync()
        {
            return _database.Table<Mechanic>().ToListAsync();
        }
        public Task<int> SaveShopAsync(Mechanic shop)
        {
            if (shop.ID != 0)
            {
                return _database.UpdateAsync(shop);
            }
            else
            {
                return _database.InsertAsync(shop);
            }
        }


    }
}
