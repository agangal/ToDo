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

        public void CurrentItems()
        {

        }

        public void CurrentItems(DateTime startDate)
        {

        }

        public void CurrentItems(DateTime fromDate, DateTime toDate)
        {

        }

        public void PausedItems()
        {
            
        }

        public static async Task<List<Item>> GetAllItems()
        {
            try
            {
                string data = await ReadFile(Settings.FileDb);
                if (String.IsNullOrEmpty(data))
                    return null;

                return JsonConvert.DeserializeObject<List<Item>>(data);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion

        #region methods adding/updating items

        public static async void AddNewItem(Item item)
        {
            List<Item> currList = await Helper.GetAllItems();
            if (currList == null)
                currList = new List<Item>();

            currList.Add(item);
            WriteFile(Settings.FileDb, JsonConvert.SerializeObject(currList));
        }

        public void  UpdateItem(Item item)
        {

        }

        public void UpdateItemState(Item item, ItemState newState)
        {

        }

        #endregion
    }
}
