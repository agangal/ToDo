using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo
{
    using Model;
    using Windows.Storage;
    using Newtonsoft.Json;

    public class Helper
    {
        #region File helper

        private static async void WriteFile(string filename, string data)
        {
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localFolder = applicationData.LocalFolder;
            StorageFile file = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, data);
        }

        private static async Task<string> ReadFile(string filename)
        {
            var applicationData = Windows.Storage.ApplicationData.Current;
            var localFolder = applicationData.LocalFolder;
            string response = null;
            StorageFile sampleFile = await localFolder.GetFileAsync(filename);
            response = await FileIO.ReadTextAsync(sampleFile);            
            return response;
        }

        #endregion

        #region methods offering up data

        public async Task<List<Item>> CurrentItems()
        {
            List<Item> allItems =  (await this.GetAllItems()).ToList();
            allItems = allItems.Where(c => c.State == ItemState.Created).ToList();
            return allItems;
        }

        public void CurrentItems(DateTime startDate)
        {

        }

        public void CurrentItems(DateTime fromDate, DateTime toDate)
        {

        }

        public async Task<List<Item>> PausedItems()
        {
            List<Item> allItems = (await this.GetAllItems()).ToList();
            allItems = allItems.Where(c => c.State == ItemState.Paused).ToList();
            return allItems;
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            try
            {
                string data = await ReadFile(Settings.FileDb);
                if (String.IsNullOrEmpty(data))
                    return new List<Item>();

                return JsonConvert.DeserializeObject<List<Item>>(data);
            }
            catch (Exception ex)
            {
                return new List<Item>();
            }
        }

        #endregion

        #region methods adding/updating items

        public async void AddNewItem(Item item)
        {
            List<Item> currList = (await this.GetAllItems()).ToList();
            if (currList == null)
                currList = new List<Item>();

            currList.Add(item);
            WriteFile(Settings.FileDb, JsonConvert.SerializeObject(currList));
        }

        public async void UpdateItem(Item item)
        {
            List<Item> allItems = (await this.GetAllItems()).ToList();
            if (String.IsNullOrEmpty(item.Id))
                item.Id = Guid.NewGuid().ToString();

            List<Item> updatedItems = new List<Item>();
            foreach (var obj in allItems)
            {                
                if (obj.IsEquivalent(item))
                {
                    updatedItems.Add(item);
                }
                else
                {
                    updatedItems.Add(obj);
                }
            }

            WriteFile(Settings.FileDb, JsonConvert.SerializeObject(updatedItems));
        }

        #endregion
    }
}
