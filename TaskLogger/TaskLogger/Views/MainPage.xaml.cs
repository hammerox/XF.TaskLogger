using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TaskLogger.Models;
using System.Collections.ObjectModel;

namespace TaskLogger.Views
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<Activity> ActivityList { get; private set; }


        public MainPage()
		{
			InitializeComponent();
            ActivityList = MockedList();
            BindingContext = this;
            ActivityView.ItemSelected += (sender, e) => {
                var selectedActivity = (Activity)((ListView)sender).SelectedItem;
                var detailPage = new DetailPage(selectedActivity);
                Navigation.PushAsync(detailPage);
            };
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
