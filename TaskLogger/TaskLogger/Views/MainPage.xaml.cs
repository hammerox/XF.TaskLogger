using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TaskLogger.Models;
using System.Collections.ObjectModel;
using TaskLogger.Repositories;

namespace TaskLogger.Views
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<Activity> ActivityList { get; private set; }
        public ActivityRepository repo;


        public MainPage()
		{
			InitializeComponent();
            repo = ActivityRepository.Instance;

            ActivityList = DatabaseList();
            BindingContext = this;
            ActivityView.ItemSelected += (sender, e) => {
                var selectedActivity = (Activity)((ListView)sender).SelectedItem;
                if (selectedActivity != null)
                {
                    var detailPage = new DetailPage((Activity) selectedActivity.Clone());
                    Navigation.PushAsync(detailPage);
                    ((ListView)sender).SelectedItem = null;
                }
            };
        }

        private ObservableCollection<Activity> DatabaseList()
        {
            List < Activity > list = repo.GetActivities().ToList();
            if (list.Count == 0)
            {
                MockedList().ForEach(x => repo.SalvarActivity(x));
                list = repo.GetActivities().ToList();
            }
            return new ObservableCollection<Activity>(list);
        }

        private List<Activity> MockedList()
        {
            var list = new List<Activity>();
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

        private void Add_Clicked(object sender, EventArgs e)
        {
            var detailPage = new DetailPage(null);
            Navigation.PushAsync(detailPage);
        }
    }
}
