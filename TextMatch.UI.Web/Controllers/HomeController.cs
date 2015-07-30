namespace TextMatch.UI.Web.Controllers
{
	using System.Collections.Generic;
	using System.Web.Mvc;

	using Models.Home;

	using Services;

	public partial class HomeController : BaseController
	{
		public virtual ActionResult Index()
		{
			var model = this.BuildIndexViewModel();

			return this.View(this.Views.Index, model);
		}

		[HttpPost]
		public virtual ActionResult GetSubTextPositions([Bind(Prefix = GetSubTextPositionsViewModel.FormName)]GetSubTextPositionsViewModel inputForm)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(this.Views.Index, this.BuildIndexViewModel());
			}

			var result = StringUtilities.GetSubTextPositions(inputForm.Text, inputForm.SubText);

			var model = this.BuildIndexViewModel(result);

			return this.View(this.Views.Index, model);
		}

		private IndexViewModel BuildIndexViewModel(ICollection<int> result = null)
		{
			return new IndexViewModel
			{
				GetSubTextPositionsForm = new GetSubTextPositionsViewModel(),
				SubTextPositionsResult = result
			};
		}
	}
}