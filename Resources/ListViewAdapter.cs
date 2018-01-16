using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using moneyShow.Resources.model;

namespace moneyShow.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView benrizhichu { get; set; }
        public TextView benrishouru { get; set; }
        public TextView jinrishouru { get; set; }
        public TextView jinrizhuchu { get; set; }
        public TextView benzhoushouru { get; set; }
        public TextView benzhouzhuchu { get; set; }
        public TextView benyueshouru { get; set; }
        public TextView benyuezhuchu { get; set; }

    }

    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        //private List<Person> lstPerson;
        private List<Money> lstMoney;
        private List<Budget> lstBudget;


        //public ListViewAdapter(Activity activity,List<Person> lstPerson){
        //    this.activity = activity;
        //    this.lstPerson = lstPerson;
        //}

        public ListViewAdapter(Activity activity, List<Money> lstMoney, List<Budget> lstBudget)
        {
            this.activity = activity;
            this.lstMoney = lstMoney;
            this.lstBudget = lstBudget;
        }


        public override int Count
        {
            get
            {
                return lstMoney.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return lstMoney[position].ID;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_dataTemplate, parent, false);

            //var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            //var txtAge = view.FindViewById<TextView>(Resource.Id.textView2);
            //var txtEmail = view.FindViewById<TextView>(Resource.Id.textView3);

            //txtName.Text = lstPerson[position].Name;
            //txtAge.Text = ""+lstPerson[position].Age;
            //txtEmail.Text = lstPerson[position].Email;

            //homepage面板
            var txtbenrizhichu = view.FindViewById<TextView>(Resource.Id.benrizhichu);
            var txtbenrishouru = view.FindViewById<TextView>(Resource.Id.benrishouru);

            var txtjinrishouru = view.FindViewById<TextView>(Resource.Id.benrishouru);
            var txtjinrizhichu = view.FindViewById<TextView>(Resource.Id.benrizhichu);

            var txtbenzhoushouru = view.FindViewById<TextView>(Resource.Id.benzhoushouru);
            var txtbenzhouzhichu = view.FindViewById<TextView>(Resource.Id.benzhouzhichu);

            var txtbenyueshouru = view.FindViewById<TextView>(Resource.Id.benyueshouru);
            var txtbenyuezhichu = view.FindViewById<TextView>(Resource.Id.benyuezhichu);

            //dayaccount面板
            var txtshou1num = view.FindViewById<TextView>(Resource.Id.shou1num);
            var txtzhi1num = view.FindViewById<TextView>(Resource.Id.zhi1num);
            var txtjieyu1num = view.FindViewById<TextView>(Resource.Id.jieyu1num);

            var txtshou2num = view.FindViewById<TextView>(Resource.Id.shou2num);
            var txtzhi2num = view.FindViewById<TextView>(Resource.Id.zhi2num);
            var txtjieyu2num = view.FindViewById<TextView>(Resource.Id.jieyu2num);

            var txtshou3num = view.FindViewById<TextView>(Resource.Id.shou3num);
            var txtzhi3num = view.FindViewById<TextView>(Resource.Id.zhi3num);
            var txtjieyu3num = view.FindViewById<TextView>(Resource.Id.jieyu3num);

            var txtshou4num = view.FindViewById<TextView>(Resource.Id.shou4num);
            var txtzhi4num = view.FindViewById<TextView>(Resource.Id.zhi4num);
            var txtjieyu4num = view.FindViewById<TextView>(Resource.Id.jieyu4num);

            var txtshou5num = view.FindViewById<TextView>(Resource.Id.shou5num);
            var txtzhi5num = view.FindViewById<TextView>(Resource.Id.zhi5num);
            var txtjieyu5num = view.FindViewById<TextView>(Resource.Id.jieyu5num);

            var txtshou6num = view.FindViewById<TextView>(Resource.Id.shou5num);
            var txtzhi6num = view.FindViewById<TextView>(Resource.Id.zhi5num);
            var txtjieyu6num = view.FindViewById<TextView>(Resource.Id.jieyu5num);


            return view;
        }
    }
}