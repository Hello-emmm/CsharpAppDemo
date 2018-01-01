using System;
using SQLite;

namespace moneyShow.Resources.model
{
	public class Budget
	{
		[PrimaryKey, AutoIncrement]
		public float budget { get; set; }// 设置预算
        public float init { get; set; }// 原来有多少钱
        public float current { get; set; } // 现在的（收入-消费）额
        public float budgetleft {
            get { return budget + current; }
        }
		public float actualleft
		{
			get { return init + current; }
		}

	}
}

