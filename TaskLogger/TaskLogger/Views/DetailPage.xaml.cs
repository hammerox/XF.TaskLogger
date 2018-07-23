using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLogger.Models;
using TaskLogger.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskLogger.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{

        public Activity activity { get; set; }
        private ActivityRepository repo;

        public DetailPage (Activity activity)
		{
			InitializeComponent ();
            repo = ActivityRepository.Instance;
            this.activity = (activity != null) ? activity : new Activity();
            BindingContext = this.activity;
        }

        public void OnSaveClick(object sender, EventArgs e) 
        {
            repo.SalvarActivity(this.activity);
            Navigation.PopAsync();
        }

        public void OnRemoveClick(object sender, EventArgs e) 
        {
            repo.RemoverActivity(this.activity.Id);
            Navigation.PopAsync();
        }

    }
}