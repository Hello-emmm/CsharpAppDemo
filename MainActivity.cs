using Android.App;
using Android.Widget;
using Android.OS;
using SQLitePCL;
using System.Collections.Generic;
using moneyShow.Resources.model;
using moneyShow.Resources.DataHelper;
using moneyShow.Resources;
using Android.Util;

namespace moneyShow
{
    [Activity(Label = "moneyShow", MainLauncher = true, Icon = "@mipmap/icon")]



    public class MainActivity : Activity
    {
        ListView lstData;
        List<Person> lstSource = new List<Person>();
        DataBase db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Create DataBase
            db = new DataBase();
            db.CreateDataBase();

            //System.IO.File.Delete("/data/user/0/com.hello_emmm.moneyShow/files");
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            Log.Info("DB_PATH", folder);

            var todayin = FindViewById<TextView>(Resource.Id.todayin);
            var todayout = FindViewById<TextView>(Resource.Id.todayout);
            var todayleft = FindViewById<TextView>(Resource.Id.todayleft);
            var latestin = FindViewById<TextView>(Resource.Id.latestin);
            var latestout = FindViewById<TextView>(Resource.Id.latestout);
            var monthin = FindViewById<TextView>(Resource.Id.monthin);
            var monthout = FindViewById<TextView>(Resource.Id.monthout);
            var weekin = FindViewById<TextView>(Resource.Id.weekin);
            var weekout = FindViewById<TextView>(Resource.Id.weekout);

            var btnAddRecord = FindViewById<Button>(Resource.Id.addrecord);


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
			//        var txtName = e.View.FindViewById<TextView>(Resource.Id.textView1);
			//        var txtAge = e.View.FindViewById<TextView>(Resource.Id.textView2);
			//        var txtEmail = e.View.FindViewById<TextView>(Resource.Id.textView3);

			//        edtName.Text = txtName.Text;
			//        edtName.Tag = e.Id;

			//        edtAge.Text = txtAge.Text;
			//        edtEmail.Text = txtEmail.Text;
			//    };
			//}

			//private void LoadData(){
			//    lstSource = db.selectTablePerson();
			//    var adapter = new ListViewAdapter(this, lstSource);
			//    lstData.Adapter = adapter;
			//}
		}
		private void LoadData()
		{
			lstSource = db.selectTablePerson();
			var adapter = new ListViewAdapter(this, lstSource);
			lstData.Adapter = adapter;
		}
    }
}

