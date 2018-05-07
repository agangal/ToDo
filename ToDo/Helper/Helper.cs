using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Helper
{
    using Model;
    public class Helper
    {
        #region File helper

        public void WriteFile(string filename, string data)
        {

        }
        
        public string ReadFile(string filename)
        {
            throw new NotImplementedException();
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

        public void AllItemsByDate()
        {

        }

        #endregion

        #region methods adding/updating items

        public void AddNewItem(Item item)
        {

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
