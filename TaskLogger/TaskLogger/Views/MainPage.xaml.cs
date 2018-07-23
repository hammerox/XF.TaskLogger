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
        private ActivityRepository repo;


        public MainPage()
		{
			InitializeComponent();
            repo = ActivityRepository.Instance;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ActivityList = DatabaseList();
            OnPropertyChanged("ActivityList");
        }

        private ObservableCollection<Activity> DatabaseList()
        {
            List < Activity > list = repo.GetActivities().ToList();
            if (list.Count == 0)
            {
                repo.MockedList().ForEach(x => repo.SalvarActivity(x));
                list = repo.GetActivities().ToList();
            }
            return new ObservableCollection<Activity>(list);
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            var detailPage = new DetailPage(null);
            Navigation.PushAsync(detailPage);
        }

        private void Switch_Toggled(object sender, EventArgs e)
        {
            var switchView = (SwitchView) sender;
            var selectedActivity = switchView.Activity;
            if (selectedActivity != null)
            {
                repo.SalvarActivity(selectedActivity);
            }
        }
    }
}
