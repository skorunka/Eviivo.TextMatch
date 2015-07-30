namespace TextMatch.UI.Web.Models.Home
{
	using System.ComponentModel.DataAnnotations;

	public class GetSubTextPositionsViewModel
	{
		public const string FormName = "GetSubTextPositionsForm";

		[Required]
		[Display(Name = "Source text", Prompt = "surce text")]
		public string Text { get; set; }

		[Required]
		[Display(Name = "Text to search for", Prompt = "sub text")]
		public string SubText { get; set; }
	}
}