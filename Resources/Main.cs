
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace moneyShow.Resources
{
    [Activity(Label = "Main")]
    public class ViewHolder : Java.Lang.Object
    {
        public TextView canyinzhichu { get; set; }
        public TextView txtAge { get; set; }
        public TextView txtEmail { get; set; }

    public class Main : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}
