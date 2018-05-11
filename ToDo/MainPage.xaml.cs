using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ToDo
{
    using Model;
    using System.Collections.ObjectModel;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Item> currentItemList { get; set; }
        public string DayNum = DateTime.Now.Day.ToString();
        public MainPage()
        {
            this.InitializeComponent();
            currentItemList = new ObservableCollection<Item>();            
        }

        /// <summary>
        /// On page load, load existing items in to the view
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IEnumerable<Item> coll = await Helper.GetAllItems();

            if (!(coll == null || coll.Count() == 0))
                currentItemList = new ObservableCollection<Item>(coll);
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CompleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            string d = NewTask.Text;
            Item item = new Item { Title = d, Start = DateTime.UtcNow, State = ItemState.Created };
            Helper.AddNewItem(item);
        }
    }
}
