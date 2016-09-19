using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace crontab
{
	public class Month
	{
		private List<int> validElems = null;

		private int min = 1;
		private int max = 12;

		public Month(string elem)
		{
			this.validElems = this.ParseElem(elem);
		}

		public bool Contains(int targetMonth)
		{
			return this.validElems.Contains(targetMonth);
		}

		private List<int> ParseElem(string elem)
		{
			var parsedValues = new List<int>();
			if (elem == "*")
			{
				for (int i = this.min; i <= this.max; i++)
				{
					parsedValues.Add(i);
				}
				return parsedValues;
			}

			var convertedRange = Regex.Replace(
				elem,
				@"(\d+)\-(\d+)",
				new MatchEvaluator(ExpandRange));
			
			var numbers = new List<string>(convertedRange.Split(','));
			numbers.ForEach(number => {
				parsedValues.Add(int.Parse(number));
			});

			return parsedValues;
		}

		private static string ExpandRange(Match m)
		{
			var matchedMin = int.Parse(m.Groups[1].Value);
			var matchedMax = int.Parse(m.Groups[2].Value);

			List<string> rangeStrings = new List<string>();
			for (int i = matchedMin; i <= matchedMax; i++)
			{
				rangeStrings.Add(i.ToString());
			}

			return String.Join(",", rangeStrings.ToArray());
		}
	}
}
