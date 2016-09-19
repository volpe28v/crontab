using NUnit.Framework;
using System;
using crontab;
namespace crontab_test
{
	[TestFixture()]
	public class MonthTest
	{
		[Test()]
		public void 月のパースができること_全て()
		{
			Month month = new Month("*");

			for (int i = 1; i <= 12; i++)
			{
				month.Contains(i).IsTrue();
			}
		}

		[Test()]
		public void 月のパースができること_値()
		{
			Month month = new Month("9");

			month.Contains(9).IsTrue();
		}

		[Test()]
		public void 月のパースができること_値列()
		{
			Month month = new Month("1,3,6,9,12");

			month.Contains(1).IsTrue();
			month.Contains(3).IsTrue();
			month.Contains(6).IsTrue();
			month.Contains(9).IsTrue();
			month.Contains(12).IsTrue();
		}

		[Test()]
		public void 月のパースができること_範囲()
		{
			Month month = new Month("3-9");

			month.Contains(1).IsFalse();
			month.Contains(2).IsFalse();
			month.Contains(3).IsTrue();
			month.Contains(4).IsTrue();
			month.Contains(5).IsTrue();
			month.Contains(6).IsTrue();
			month.Contains(7).IsTrue();
			month.Contains(8).IsTrue();
			month.Contains(9).IsTrue();
			month.Contains(10).IsFalse();
			month.Contains(11).IsFalse();
			month.Contains(12).IsFalse();
		}

		[Test()]
		public void 月のパースができること_範囲と値()
		{
			Month month = new Month("1,3-9,12");

			month.Contains(1).IsTrue();
			month.Contains(2).IsFalse();
			month.Contains(3).IsTrue();
			month.Contains(4).IsTrue();
			month.Contains(5).IsTrue();
			month.Contains(6).IsTrue();
			month.Contains(7).IsTrue();
			month.Contains(8).IsTrue();
			month.Contains(9).IsTrue();
			month.Contains(10).IsFalse();
			month.Contains(11).IsFalse();
			month.Contains(12).IsTrue();
		}

		[Test()]
		public void 月のパースができること_複数範囲()
		{
			Month month = new Month("3-5,7-9");

			month.Contains(1).IsFalse();
			month.Contains(2).IsFalse();
			month.Contains(3).IsTrue();
			month.Contains(4).IsTrue();
			month.Contains(5).IsTrue();
			month.Contains(6).IsFalse();
			month.Contains(7).IsTrue();
			month.Contains(8).IsTrue();
			month.Contains(9).IsTrue();
			month.Contains(10).IsFalse();
			month.Contains(11).IsFalse();
			month.Contains(12).IsFalse();

		}


	}

}
