namespace TextMatch.UI.Web.Tests.Controllers
{
	using System.Web.Mvc;

	using NUnit.Framework;

	using TextMatch.UI.Web.Models;
	using TextMatch.UI.Web.Models.Home;

	using Web.Controllers;

	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void Index()
		{
			var controller = new HomeController();

			var result = controller.Index() as ViewResult;

			Assert.IsNotNull(result);
		}

		[Test]
		public void GetSubTextPositions()
		{
			var controller = new HomeController();
			var model = new GetSubTextPositionsViewModel { Text = "text", SubText = "subtext" };

			var result = controller.GetSubTextPositions(model) as ViewResult;

			Assert.IsNotNull(result);
		}
	}
}
