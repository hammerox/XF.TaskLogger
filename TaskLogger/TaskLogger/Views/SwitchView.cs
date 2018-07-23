using System;
using System.Collections.Generic;
using System.Text;
using TaskLogger.Models;
using Xamarin.Forms;

namespace TaskLogger.Views
{
    public class SwitchView : Switch
    {
        public static readonly BindableProperty ActivityProperty = BindableProperty.Create(propertyName: "Activity", returnType: typeof(Activity), declaringType: typeof(SwitchView), defaultValue: null);
        public Activity Activity
        {
            get
            {
                return (Activity) GetValue(ActivityProperty);
            }
            set
            {
                SetValue(ActivityProperty, value);
            }
        }
    }
}
