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

        private DateTime now = DateTime.Now;

		private DateTime _startDate;
		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}

		private DateTime _endDate;
		public DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}

		public bool CreateDataBase()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					connection.CreateTable<Money>();
                    connection.CreateTable<Budget>();
                    Budget initial = new Budget();
                    initial.init = 1000;
                    initial.budget = 1000;
                    connection.Insert(initial);
					return true;
				};
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return false;
			}
		}

        public List<Money> SelectMonth(int month){
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
                {
                    if(month == 0){
                        StartDate = DateTimeExtensions.StartOfMonth(DateTime.Today);
                        EndDate = now;
                    }else{
						StartDate = new DateTime(now.Year, month, 1);
						EndDate = StartDate.AddMonths(1);
                    }
                    List<Money> moneylist = connection.Query<Money>("SELECT * FROM Money WHERE date BETWEEN ? AND ?;",StartDate.ToString("YYYY-MM-DD") ,EndDate.ToString("YYYY-MM-DD"));
                    return moneylist;
                }
            }
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
        }

        public List<Money> ThisWeek(){
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					StartDate = DateTimeExtensions.StartOfWeek(DateTime.Today, DayOfWeek.Monday);
					EndDate = DateTime.Now;
					List<Money> moneylist = connection.Query<Money>("SELECT * FROM Money WHERE date BETWEEN ? AND ?;", StartDate.ToString("YYYY-MM-DD"), EndDate.ToString("YYYY-MM-DD"));
                    return moneylist;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
        }

        public List<Money> SelectYear(int year){
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					if (year == 0)
					{
                        StartDate = DateTimeExtensions.StartOfYear(DateTime.Today);
						EndDate = now;
					}
					else
					{
						StartDate = new DateTime(year, 1, 1);
						EndDate = StartDate.AddYears(1);
					}
					List<Money> moneylist = connection.Query<Money>("SELECT * FROM Money WHERE date BETWEEN ? AND ?;", StartDate.ToString("YYYY-MM-DD"), EndDate.ToString("YYYY-MM-DD"));
					return moneylist;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
        }

        public List<Money> SelectLatest(){
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					List<Money> moneylist = connection.Query<Money>("SELECT * FROM Money ORDER BY column DESC LIMIT 1;");
					return moneylist;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}

        }

        public float[] ThisWeekSum(){
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
                    float[] weekSum = new float[2];
					StartDate = DateTimeExtensions.StartOfWeek(DateTime.Today, DayOfWeek.Monday);
					EndDate = now;
                    float weekin = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE type = 0 AND date BETWEEN ? AND ?;",StartDate.ToString("YYYY-MM-DD"), EndDate.ToString("YYYY-MM-DD"));
                    float weekout = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE type = 1 AND date BETWEEN ? AND ?;", StartDate.ToString("YYYY-MM-DD"), EndDate.ToString("YYYY-MM-DD"));
                    weekSum[0] = weekin;
                    weekSum[1] = weekout;
                    return weekSum;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
        }

		public float[] ThisMonthSum()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					float[] monthSum = new float[2];
					StartDate = DateTimeExtensions.StartOfMonth(DateTime.Today);
					EndDate = now;
					float weekin = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE type = 0 AND date BETWEEN ? AND ?;", StartDate.ToString("YYYY-MM-DD"), EndDate.ToString("YYYY-MM-DD"));
					float weekout = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE type = 1 AND date BETWEEN ? AND ?;", StartDate.ToString("YYYY-MM-DD"), EndDate.ToString("YYYY-MM-DD"));
					monthSum[0] = weekin;
					monthSum[1] = weekout;
					return monthSum;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
		}

		public float[] TodaySum()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					float[] daySum = new float[2];
					StartDate = DateTimeExtensions.StartOfMonth(DateTime.Today);
					float dayin = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE type = 0 AND date = ?;", StartDate.ToString("YYYY-MM-DD"));
                    float dayout = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE type = 1 AND date = ?;", StartDate.ToString("YYYY-MM-DD"));
					daySum[0] = dayin;
					daySum[1] = dayout;
					return daySum;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
		}

        public float[] SelectMainInfo(){
            float[] result = new float[5];

			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
                    // latest
                    List<Money> latest = SelectLatest();
                    if(latest[0].type == 0){
                        result[0] = latest[0].cost;
                        result[1] = 0;
                    }else{
						result[0] = 0;
						result[1] = latest[0].cost;
                    }

                    // thisweek
                    float[] weeksum = ThisWeekSum();
                    result[2] = weeksum[0];
                    result[3] = weeksum[1];

                    // thismonth
                    float[] monthsum = ThisMonthSum();
                    result[4] = monthsum[0];
                    result[5] = monthsum[1];

                    // today
                    float[] daysum = TodaySum();
                    result[6] = daysum[0];
                    result[7] = daysum[1];

                    return result;
				};
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
        }

        public List<Money> SelectAll(){
			  try
			  {
			      using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
			      {
			          return connection.Table<Money>().ToList();
			      };
			  }
			  catch (SQLiteException ex)
			  {
			      Log.Info("SQLiteEx", ex.Message);
			      return null;
			  }
		}

        public float[] SelectType(int month, int category){
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					float[] categorySum = new float[2];
					if (month == 0)
					{
						StartDate = DateTimeExtensions.StartOfMonth(DateTime.Today);
						EndDate = now;
					}
					else
					{
						StartDate = new DateTime(now.Year, month, 1);
						EndDate = StartDate.AddMonths(1);
					}
                    float categoryin = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE category = ? AND date BETWEEN ? AND ?;", category,StartDate.ToString("YYYY-MM-DD"),EndDate.ToString("YYYY-MM-DD"));
					float categoryout = connection.ExecuteScalar<float>("SELECT sum(cost) FROM Money WHERE category = ? AND date BETWEEN ? AND ?;", category ,StartDate.ToString("YYYY-MM-DD"),EndDate.ToString("YYYY-MM-DD"));
					categorySum[0] = categoryin;
					categorySum[1] = categoryout;
					return categorySum;
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
        }

		public bool InsertIntoTableMoney(Money money)
		{
		  try
		  {
		      using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
		      {
                    if(money.type == 0){
                        money.current = QueryBudget()[2] + money.cost;
                    }else{
                        money.current = QueryBudget()[2] - money.cost;
                    }
                    UpdateBudgetCurrent(money.current); // 改变Budget表的Current值
		            connection.Insert(money);
		            return true;
		      };
		  }
		  catch (SQLiteException ex)
		  {
		      Log.Info("SQLiteEx", ex.Message);
		      return false;
		  }
		}

        public float[] QueryBudget()
        {
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					float[] budgetinfo = new float[4];
                    float current = connection.ExecuteScalar<float>("SELECT current FROM Budget;");
                    float budget = connection.ExecuteScalar<float>("SELECT budget FROM Budget;");
                    float init = connection.ExecuteScalar<float>("SELECT init FROM Budget;");
                    float left = connection.ExecuteScalar<float>("SELECT left FROM Budget;");
					budgetinfo[0] = budget;
					budgetinfo[1] = init;
                    budgetinfo[2] = current;
                    budgetinfo[3] = left;
					return budgetinfo;
                }
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return null;
			}
        }

        private bool UpdateBudgetCurrent(float current)
        {
			  try
			  {
			      using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
			      {
                    connection.Query<Budget>("UPDATE Budget set current=?;",current);
			          return true;
			      };
			  }
			  catch (SQLiteException ex)
			  {
			      Log.Info("SQLiteEx", ex.Message);
			      return false;
			  }
		}

        public float BudgetAndCurrent(){
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					float left = connection.ExecuteScalar<float>("SELECT budgetleft FROM Budget;");
                    return left; // = budget + current 如果大于0说明还没超预算
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return 0;
			}
        }
		public float InitAndCurrent()
		{
			try
			{
				using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Money.db")))
				{
					float left = connection.ExecuteScalar<float>("SELECT actualleft FROM Budget;");
					return left; // = budget + current 如果大于0说明还没超预算
				}
			}
			catch (SQLiteException ex)
			{
				Log.Info("SQLiteEx", ex.Message);
				return 0;
			}
		}




		//      public bool CreateDataBase(){
		//          try{
		//              using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder,"Persons.db"))){
		//                  connection.CreateTable<Person>();
		//                  return true;
		//              } ;
		//          }
		//          catch(SQLiteException ex){
		//              Log.Info("SQLiteEx", ex.Message);
		//              return false;
		//          }
		//      }

		//public bool InsertIntoTablePerson(Person person)
		//{
		//	try
		//	{
		//		using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
		//		{
		//			connection.Insert(person);
		//			return true;
		//		};
		//	}
		//	catch (SQLiteException ex)
		//	{
		//		Log.Info("SQLiteEx", ex.Message);
		//		return false;
		//	}
		//}

		//public List<Person> selectTablePerson()
		//{
		//	try
		//	{
		//		using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
		//		{
		//			return connection.Table<Person>().ToList();
		//		};
		//	}
		//	catch (SQLiteException ex)
		//	{
		//		Log.Info("SQLiteEx", ex.Message);
		//		return null;
		//	}
		//}

		//public bool updateTablePerson(Person person)
		//{
		//	try
		//	{
		//		using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
		//		{
		//			connection.Query<Person>("UPDATE Person set Name=?,Age=?,Email=? Where ID = ?",person.Name,person.Age,person.Email,person.ID);
		//			return true;
		//		};
		//	}
		//	catch (SQLiteException ex)
		//	{
		//		Log.Info("SQLiteEx", ex.Message);
		//		return false;
		//	}
		//}

		//public bool deleteTablePerson(Person person)
		//{
		//	try
		//	{
		//		using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
		//		{
		//			connection.Delete(person);
		//                  return true;
		//		};
		//	}
		//	catch (SQLiteException ex)
		//	{
		//		Log.Info("SQLiteEx", ex.Message);
		//		return false;
		//	}
		//}

		//public bool selectQueryTablePerson(int ID)
		//{
		//	try
		//	{
		//		using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
		//		{
		//			connection.Query<Person>("SELECT * FROM Person Where ID = ?", ID);
		//			return true;
		//		};
		//	}
		//	catch (SQLiteException ex)
		//	{
		//		Log.Info("SQLiteEx", ex.Message);
		//		return false;
		//	}
		//}
	}
}
