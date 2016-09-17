using NUnit.Framework;
using System;
using crontab;

namespace crontab_test
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void 秒指定の次の時間が取得できること()
		{
			// 秒、分、時、日、月、曜日
			var target = new Crontab("10 * * * * *");
			var nextTime = target.GetNext(new DateTime(2016, 9, 18, 0, 25, 0));
			nextTime.Is(new DateTime(2016, 9, 18, 0, 25, 10));
		}
	}
}
