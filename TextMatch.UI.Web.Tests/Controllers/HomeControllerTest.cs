namespace TextMatch.UI.Web.Tests.Controllers
{
	using System.Web.Mvc;

	using NUnit.Framework;

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
	}
}
