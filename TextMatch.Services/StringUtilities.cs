namespace TextMatch.Services
{
	using System.Collections;
	using System.Collections.Generic;

	public static class StringUtilities
	{
		public static ICollection<int> GetSubtextPositions(string text, string subText)
		{
			var sub = subText.ToCharArray();

			var positions = new List<int>(sub.Length);

			for (var i = 0; i < text.Length; i++)
			{
				var found = true;
				for (var j = 0; j < sub.Length; j++)
				{
					if (text[i + j] != sub[j])
					{
						found = false;
						break;
					}
				}

				if (found)
				{
					positions.Add(i);
				}
			}

			return positions;
		}
	}
}