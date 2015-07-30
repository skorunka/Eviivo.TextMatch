namespace TextMatch.UI.Web.Controllers
{
	using System.Web.Mvc;

	using TextMatch.UI.Web.Models;

	public partial class HomeController : BaseController
	{
		public virtual ActionResult Index()
		{
			return this.View(MVC.Home.Views.Index);
		}

		[HttpPost]
		public virtual ActionResult GetSubTextPositions(GetSubTextPositionsViewModel model)
		{
			return View();
		}
	}
}