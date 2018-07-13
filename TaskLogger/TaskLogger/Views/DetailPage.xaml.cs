using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskLogger.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskLogger.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{

        public Activity activity { get; set; }

		public DetailPage (Activity activity)
		{
			InitializeComponent ();
            this.activity = activity;
            Text.Text = activity.Name;

        }
	}
}