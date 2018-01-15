using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using moneyShow.Resources.model;

namespace moneyShow.Resources
{
    public class ViewHolder : Java.Lang.Object{
        public TextView benrizhichu { get; set; }
        public TextView benrishouru { get; set; }
        public TextView jinrishouru { get; set; }
        public TextView jinrizhuchu { get; set; }
        public TextView benzhoushouru { get; set; }
        public TextView benzhouzhuchu { get; set; }
        public TextView benyueshouru { get; set; }
        public TextView benyuezhuchu { get; set; }

    }

    }
    public class ListViewAdapter:BaseAdapter
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


        public override int Count{
            get
            {
                return lstMoney.Count;   
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        //public override long GetItemId(int position)
        //{
        //    return lstPerson[position].ID;
        //}

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_dataTemplate, parent,false);

            //var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            //var txtAge = view.FindViewById<TextView>(Resource.Id.textView2);
            //var txtEmail = view.FindViewById<TextView>(Resource.Id.textView3);

            //txtName.Text = lstPerson[position].Name;
            //txtAge.Text = ""+lstPerson[position].Age;
            //txtEmail.Text = lstPerson[position].Email;
            
          
            var txtbenrizhichu = view.FindViewById<TextView>(Resource.Id.benrizhichu);
            var txtbenrishouru = view.FindViewById<TextView>(Resource.Id.benrishouru);

            var txtjinrishouru = view.FindViewById<TextView>(Resource.Id.benrishouru);
            var txtjinrizhichu = view.FindViewById<TextView>(Resource.Id.benrizhichu);

            var txtbenzhoushouru = view.FindViewById<TextView>(Resource.Id.benzhoushouru);
            var txtbenzhouzhichu = view.FindViewById<TextView>(Resource.Id.benzhouzhichu);

            var txtbenyueshouru = view.FindViewById<TextView>(Resource.ThisMonthSum(0).benyueshouru);
            var txtbenyuezhichu = view.FindViewById<TextView>(Resource.ThisMonthSum(1).benyuezhichu);

       

            return view;
        }
    }
}
