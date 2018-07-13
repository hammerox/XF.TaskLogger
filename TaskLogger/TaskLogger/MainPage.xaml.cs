using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TaskLogger.Models;
using System.Collections.ObjectModel;

namespace TaskLogger
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<Activity> ActivityList { get; private set; }


        public MainPage()
		{
			InitializeComponent();
            ActivityList = MockedList();
            //ActivityView.ItemsSource = ActivityList;
            BindingContext = this;
		}

        private ObservableCollection<Activity> MockedList()
        {
            var list = new ObservableCollection<Activity>();
            list.Add(new Activity()
            {
                Name = "Gym",
                Description = "Byceps, Quads and Abs",
                Date = new DateTime(1531443341),
                IsCompleted = false
            });
            list.Add(new Activity()
            {
                Name = "Shopping",
                Description = "I need to buy a lot of clothes",
                Date = new DateTime(1530665741),
                IsCompleted = true
            });
            return list;
        }
	}
}
