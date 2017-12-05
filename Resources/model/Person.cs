using System;
using SQLite;

namespace moneyShow.Resources.model
{
    public class Person
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Email { get; set; }
    }
}
