using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model
{
    public class Item
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ItemState State { get; set; }

        public bool IsEquivalent(Item item)
        {
            if (this.Id.Equals(item.Id))
                return true;         

            return false;
        }
    }

    public enum ItemState
    {
        Created,        
        Paused,
        Canceled,
        Completed
    }


}
