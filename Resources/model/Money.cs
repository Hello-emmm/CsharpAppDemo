﻿using System;
using SQLite;

namespace moneyShow.Resources.model
{
	public class Money
	{
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int type { get; set; }
        public float cost { get; set; }
		public int category { get; set; }
        public string beizhu { get; set; }
		public DateTime time { get; set; }
        public float current { get; set; }

        public static implicit operator Money(Money v)
        {
            throw new NotImplementedException();
        }
    }
}

