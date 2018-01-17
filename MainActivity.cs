using Android.App;
using Android.Widget;
using Android.OS;
using SQLitePCL;
using System.Collections.Generic;
using moneyShow.Resources.model;
using moneyShow.Resources.DataHelper;
using moneyShow.Resources;
using Android.Util;
using System;

namespace moneyShow
{
    [Activity(Label = "moneyShow", MainLauncher = true, Icon = "@mipmap/icon")]



    public class MainActivity : Activity
    {
        ListView lstData;
        //List<Person> lstSource = new List<Person>();
        List<Money> lstMoney = new List<Money>();
        List<Budget> lstBudget = new List<Budget>();
        DataBase db;

        protected override void OnCreate(Bundle savedInstancesState)
        {
            //base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.duoyibi);

            // Create DataBase
            db = new DataBase();
            db.CreateDataBase();

            //System.IO.File.Delete("/data/user/0/com.hello_emmm.moneyShow/files");
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("DB_PATH", folder);

            //homepage.axml
            var todayin = FindViewById<TextView>(Resource.Id.benrishouru);
            var todayout = FindViewById<TextView>(Resource.Id.benrizhichu);
            var monthleft = FindViewById<TextView>(Resource.Id.benyueyue);

            var latestin = FindViewById<TextView>(Resource.Id.jinrishouru);
            var latestout = FindViewById<TextView>(Resource.Id.jinrizhichu);
            var monthin = FindViewById<TextView>(Resource.Id.benyueshouru);
            var monthout = FindViewById<TextView>(Resource.Id.benyuezhichu);
            var weekin = FindViewById<TextView>(Resource.Id.benzhoushouru);
            var weekout = FindViewById<TextView>(Resource.Id.benzhouzhichu);

            //var btnAddRecord = FindViewById<Button>(Resource.Id.addrecord);
            var btnAdd = FindViewById<Button>(Resource.Id.submit);

            //duoyibi.axml
            var edtBeizhu = FindViewById<TextView>(Resource.Id.beizhuinput);
            var edtCost = FindViewById<TextView>(Resource.Id.costinput);
            var edtCategory = FindViewById<TextView>(Resource.Id.foodButtond);
            var edtTime = FindViewById<TextView>(Resource.Id.timeinput);

            //Mainpage.axml
            var canyinzhichu = FindViewById<TextView>(Resource.Id.canyinzhichu);
            var lvyouzhichu = FindViewById<TextView>(Resource.Id.lvyouzhichu);
            var chuxingzhichu = FindViewById<TextView>(Resource.Id.chuxingzhichu);
            var yiliaozhichu = FindViewById<TextView>(Resource.Id.yiliaozhichu);
            var huafeizhichu = FindViewById<TextView>(Resource.Id.huafeizhichu);
            var shenghuoyongpinzhichu = FindViewById<TextView>(Resource.Id.shenghuoyongpinzhichu);

            //dayaccout.axml
            var shou1num = FindViewById<TextView>(Resource.Id.shou1num);
            var zhi1num = FindViewById<TextView>(Resource.Id.zhi1num);
            var jieyu1num = FindViewById<TextView>(Resource.Id.jieyu1num);

            var shou2num = FindViewById<TextView>(Resource.Id.shou2num);
            var zhi2num = FindViewById<TextView>(Resource.Id.zhi2num);
            var jieyu2num = FindViewById<TextView>(Resource.Id.jieyu2num);

            var shou3num = FindViewById<TextView>(Resource.Id.shou3num);
            var zhi3num = FindViewById<TextView>(Resource.Id.zhi3num);
            var jieyu3num = FindViewById<TextView>(Resource.Id.jieyu3num);

            var txtshou4num = FindViewById<TextView>(Resource.Id.shou4num);
            var txtzhi4num = FindViewById<TextView>(Resource.Id.zhi4num);
            var txtjieyu4num = FindViewById<TextView>(Resource.Id.jieyu4num);

            var txtshou5num = FindViewById<TextView>(Resource.Id.shou5num);
            var txtzhi5num = FindViewById<TextView>(Resource.Id.zhi5num);
            var txtjieyu5num = FindViewById<TextView>(Resource.Id.jieyu5num);

            var txtshou6num = FindViewById<TextView>(Resource.Id.shou5num);
            var txtzhi6num = FindViewById<TextView>(Resource.Id.zhi5num);
            var txtjieyu6num = FindViewById<TextView>(Resource.Id.jieyu5num);



            LoadData();

			//lstData = FindViewById<ListView>(Resource.Id.listView);

			//var edtName = FindViewById<EditText>(Resource.Id.edtName);
			//var edtAge = FindViewById<EditText>(Resource.Id.edtAge);
			//var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
			// Get our button from the layout resource,
			// and attach an event to it
			//Button btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
			//Button btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
			//Button btnDelete = FindViewById<Button>(Resource.Id.btnDelete);

			// LoadData 18：20
			//LoadData();

			//Event
			//    btnAdd.Click += delegate
			//    {
			//        Person person = new Person()
			//        {
			//            Name = edtName.Text,
			//            Age = int.Parse(edtAge.Text),
			//            Email = edtEmail.Text
			//        };
			//        db.InsertIntoTablePerson(person);
			//        LoadData();
			//    }; 
                btnAdd.Click += delegate
                {
                    Money money = new Money()
                    {
                        beizhu = edtBeizhu.Text,
                        cost = float.Parse(edtCost.Text),
                        category = int.Parse(edtCategory.Text),
                        time = DateTime.Now
                    };
                    db.InsertIntoTableMoney(money);
                    LoadData();
                }; 

			//    btnEdit.Click += delegate
			//    {
			//        Person person = new Person()
			//        {
			//            ID = int.Parse(edtName.Tag.ToString()),
			//            Name = edtName.Text,
			//            Age = int.Parse(edtAge.Text),
			//            Email = edtEmail.Text
			//        };
			//        db.updateTablePerson(person);
			//        LoadData();
			//    };

			//    btnDelete.Click += delegate
			//    {
			//        Person person = new Person()
			//        {
			//            ID = int.Parse(edtName.Tag.ToString()),
			//            Name = edtName.Text,
			//            Age = int.Parse(edtAge.Text),
			//            Email = edtEmail.Text
			//        };
			//        db.deleteTablePerson(person);
			//        LoadData();
			//    };

			//    lstData.ItemClick += (s,e) =>{
			//        // Set background for selected item
			//        for (int i = 0; i < lstData.Count;i++){
			//            if(e.Position == i)
			//                lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.DarkGray);
			//            else
			//                lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
			//        }

			//        // Binding Datata
			        //var txtName = e.View.FindViewById<TextView>(Resource.Id.textView1);
			        //var txtAge = e.View.FindViewById<TextView>(Resource.Id.textView2);
			        //var txtEmail = e.View.FindViewById<TextView>(Resource.Id.textView3);

			//        edtName.Text = txtName.Text;
			//        edtName.Tag = e.Id;

			//        edtAge.Text = txtAge.Text;
			//        edtEmail.Text = txtEmail.Text;
			//    };
			//}

   //         private void LoadData(){
   //             lstSource = db.selectTablePerson();
			//    var adapter = new ListViewAdapter(this, lstSource);
			//    lstData.Adapter = adapter;
			//}
		}
		private void LoadData()
		{
            var weekin = db.ThisWeekSum();
            TextView todayin = (TextView)FindViewById<TextView>(Resource.Id.benrishouru);
            string todayin1 = (string)todayin;
            todayin.Text = todayin1;


            var weekout = db.ThisWeekSum();
            TextView todayout = (TextView)FindViewById<TextView>(Resource.Id.benrizhichu);
            string todayout1 = (string)todayout;
            todayout.Text = todayout1;
            //List<Money> list = db.SelectYear(1);
			//var adapter = new ListViewAdapter(this, lstSource);
			//lstData.Adapter = adapter;
		}
    }
}

