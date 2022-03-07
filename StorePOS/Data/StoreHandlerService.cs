using MongoDB.Driver;
using StorePOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorePOS.Data
{
    public class StoreHandlerService
    {

        public MongoClient Client = new MongoClient("mongodb+srv://aradhya1712:Aradhya%401712@management.itpen.mongodb.net/KioskPos?retryWrites=true&w=majority");
        public IMongoDatabase Database;
        public IMongoCollection<Store> Collection;
        public StoreHandlerService()
        {
            Database = Client.GetDatabase("KioskPos");
            Collection = Database.GetCollection<Store>("Stores");
        }
        //Store
        public async Task<Store> AddNewStore(Store Store)
        {
            try
            {
                await Collection.InsertOneAsync(Store);
                return Store;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Store> GetStoreById(String Id)
        {
            try
            {
                var Result = await Collection.Find(res => res._id == Id).FirstAsync();
                return Result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Store>> GetAllStores()
        {
            try
            {
                var list = await Collection.Find(_ => true).ToListAsync();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateStore(Store Store)
        {
            try
            {
                var Filter = Builders<Store>.Filter.Eq(r => r._id, Store._id);
                await Collection.ReplaceOneAsync(Filter, Store);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteStore(String Id)
        {
            try
            {
                var deletefilter = Builders<Store>.Filter.Eq(store => store._id, Id);
                await Collection.DeleteOneAsync(deletefilter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Billing
        public async Task<Bill> AddNewBill(Bill NewBill, String StoreId)
        {
            try
            {
                var Store = await Collection.Find(res => res._id == StoreId).FirstOrDefaultAsync();
                if (Store.Bills != null)
                {
                    Store.Bills.Add(NewBill);
                }
                else
                {
                    List<Bill> BillsList = new List<Bill>();
                    BillsList.Add(NewBill);
                    Store.Bills = BillsList;
                }
                await UpdateStore(Store);
                await UpdateInventoryItemsAfterBilling(StoreId, NewBill);
                return NewBill;


            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Bill> GetBillById(String StoreId, String Billid) 
        {
            try
            {
                var result = await GetStoreById(StoreId);
                var bill = result.Bills.Find(el => el._id == Billid);
                return bill;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Bill>> GetAllBills(String StoreId)
        {
            try
            {
                var MyStore = await GetStoreById(StoreId);
                return MyStore.Bills;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Inventory
        public async Task<InventoryItem> AddNewInventoryItem(InventoryItem inventoryItem, String StoreId)
        {
            try
            {
                Store Store = await Collection.Find(res => res._id == StoreId).FirstOrDefaultAsync();
                if (Store.InventoryItems != null)
                {
                    Store.InventoryItems.Add(inventoryItem);
                }
                else
                {
                    List<InventoryItem> NewList = new List<InventoryItem>();
                    NewList.Add(inventoryItem);
                    Store.InventoryItems = NewList;
                }
                await UpdateStore(Store);
                return inventoryItem;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<InventoryItem> DeleteInventoryItem(String StoreId, String InventoryItemId)
        {
            try
            {
                var store = await GetStoreById(StoreId);
                var ItemToBeDeleted = store.InventoryItems.Find(el => el._id == InventoryItemId);
                store.InventoryItems.Remove(ItemToBeDeleted);
                await UpdateStore(store);
                return ItemToBeDeleted;
                 
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task UpdateInventoryItemsAfterBilling(String StoreId, Bill NewBill)
        {
            try
            {
                var store = await GetStoreById(StoreId);
                foreach (var item in NewBill.BillingItems)
                {
                    store.InventoryItems.Find(e => e._id == item._id).Quantity -= item.BillingQuantity;
                }
                await UpdateStore(store);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<String>> GetCategories(String StoreId)
        {
            try
            {
                var Categories = new List<String>();
                var MyStore = await GetStoreById(StoreId);
                foreach (var item in MyStore.InventoryItems)
                {
                    Categories.Add(item.Category);
                }
                Categories = Categories.Distinct().ToList();
                return Categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
