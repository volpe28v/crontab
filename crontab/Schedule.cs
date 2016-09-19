using System;
namespace crontab
{
	public class Schedule
	{
		public Month Month { get; private set; }

		public Schedule(string source)
		{
			var elems = source.Split(' ');
			this.Month = new Month(elems[0]);
		}
	}
}
