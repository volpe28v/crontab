using System;
namespace crontab
{
	public class Crontab
	{
		private Schedule schedule;

		public Crontab(string source)
		{
			// 項目をパース
			this.schedule = new Schedule(source); 
		}

		public DateTime GetNext(DateTime baseTime)
		{
			var currentTime = baseTime.AddSeconds(1);
			while (true)
			{
				if (!this.IsInThisMonth(currentTime))
				{
					currentTime = currentTime.AddMonths(1);
					currentTime = new DateTime(currentTime.Year, 
					                           currentTime.Month, 
					                           1, 
					                           0, 
					                           0, 
					                           0);
				}
				else if (!this.IsInThisDay(currentTime))
				{
					currentTime = currentTime.AddDays(1);
					currentTime = new DateTime(currentTime.Year, 
					                           currentTime.Month, 
					                           currentTime.Day, 
					                           0, 
					                           0, 
					                           0);
				}
				else if (!this.IsInThisHour(currentTime))
				{
					currentTime = currentTime.AddHours(1);
					currentTime = new DateTime(currentTime.Year, 
					                           currentTime.Month, 
					                           currentTime.Day, 
					                           currentTime.Hour, 
					                           0, 
					                           0);
				}
				else if (!this.IsInThisMinute(currentTime))
				{
					currentTime = currentTime.AddMinutes(1);
					currentTime = new DateTime(currentTime.Year, 
					                           currentTime.Month, 
					                           currentTime.Day, 
					                           currentTime.Hour, 
					                           currentTime.Minute, 
					                           0);
				}
				else if (!this.IsInThisSecond(currentTime))
				{
					currentTime = currentTime.AddSeconds(1);
				}
				else {
					// マッチ
					return currentTime;
				}
			}
		}

		private bool IsInThisMonth(DateTime currentTime)
		{
			return this.schedule.Month.Contains(currentTime.Month);
		}

		private bool IsInThisDay(DateTime currentTime)
		{
			return true;
		}

		private bool IsInThisHour(DateTime currentTime)
		{
			return true;
		}

		private bool IsInThisMinute(DateTime currentTime)
		{
			return true;
		}

		private bool IsInThisSecond(DateTime currentTime)
		{
			return true;
		}

	}
}
