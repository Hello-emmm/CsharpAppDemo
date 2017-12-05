using System;
using SQLite;
using moneyShow.Resources.model;
using Android.Util;
using System.Collections.Generic;
using System.Linq;

namespace moneyShow.Resources.DataHelper
{
    
    public class DataBase
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool CreateDataBase(){
            try{
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"Persons.db"))){
                    connection.CreateTable<Person>();
                    return true;
                } ;
            }
            catch(SQLiteException ex){
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

		public bool InsertIntoTablePerson(Person person)
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
				{
					connection.Insert(person);
					return true;
				};
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}

		public List<Person> selectTablePerson()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
				{
					return connection.Table<Person>().ToList();
				};
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
		}

		public bool updateTablePerson(Person person)
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
				{
					connection.Query<Person>("UPDATE Person set Name=?,Age=?,Email=? Where ID = ?",person.Name,person.Age,person.Email,person.ID);
					return true;
				};
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}

		public bool deleteTablePerson(Person person)
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
				{
					connection.Delete(person);
                    return true;
				};
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}

		public bool selectQueryTablePerson(int ID)
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
				{
					connection.Query<Person>("SELECT * FROM Person Where ID = ?", ID);
					return true;
				};
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}
    }
}
