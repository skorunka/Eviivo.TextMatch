namespace TextMatch.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public static class StringUtilities
	{
		public static ICollection<int> GetSubTextPositions(string text, string subText)
		{
			text = text.ToLower();
			subText = subText.ToLower();

			var positions = new List<int>();

			Parallel.For(0, text.Length,
				position =>
					{
						var matchFound = IsSubTextOnPosition(position, text, subText);

						if (matchFound)
						{
							positions.Add(position + 1);
						}
					});

			return positions;
		}

		private static bool IsSubTextOnPosition(int position, string text, string subText)
		{
			if (position > text.Length - subText.Length)
			{
				return false;
			}

			for (var i = 0; i < subText.Length; i++)
			{
				if (text[position + i] != subText[i])
				{
					return false;
				}
			}

			return true;
		}
	}
}