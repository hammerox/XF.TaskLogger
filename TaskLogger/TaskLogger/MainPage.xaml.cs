using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TaskLogger.Models;

namespace TaskLogger
{
	public partial class MainPage : ContentPage
	{
        public List<Activity> activityList;


		public MainPage()
		{
			InitializeComponent();
            activityList = MockedList();
		}

        private List<Activity> MockedList()
        {
            var list = new List<Activity>();
            list.Add(new Activity("Gym", "Byceps, Quads and Abs", new DateTime(1531443341), false));
            list.Add(new Activity("Shopping", "I need to buy a lot of clothes", new DateTime(1530665741), true));
            return list;
        }
	}
}
