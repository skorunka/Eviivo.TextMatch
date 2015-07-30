namespace TextMatch.UI.Web.Models.Home
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class IndexViewModel
	{
		[UIHint("SubTextPositionsForm")]
		public GetSubTextPositionsViewModel GetSubTextPositionsForm { get; set; }

		[UIHint("SubTextPositionsResult")]
		public ICollection<int> SubTextPositionsResult { get; set; }
	}
}