using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Model
{
    public class Item
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ItemState State { get; set; }
    }

    public enum ItemState
    {
        Created,
        NotStarted,
        InProgress,
        Paused,
        Abandoned,
        Completed
    }


}
