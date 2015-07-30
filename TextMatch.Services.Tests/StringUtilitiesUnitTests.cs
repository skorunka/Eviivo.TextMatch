// ReSharper disable ConvertToConstant.Local
// ReSharper disable InconsistentNaming
namespace TextMatch.Services.Tests
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	using NUnit.Framework;

	[TestFixture]
	public class StringUtilitiesUnitTests
	{
		[Test]
		public void ShouldReturnOneWhenLookingForAInA()
		{
			var text = "A";
			var subText = "A";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsNotEmpty(result);
			Assert.AreEqual(1, result.Count);
			CollectionAssert.Contains(result, 1);
		}

		[Test]
		public void ShouldReturnTwoWhenLookingForBInAB()
		{
			var text = "AB";
			var subText = "B";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsNotEmpty(result);
			Assert.AreEqual(1, result.Count);
			CollectionAssert.Contains(result, 2);
		}

		[Test]
		public void ShouldReturnTwoFourWhenLookingForBInABAB()
		{
			var text = "ABAB";
			var subText = "B";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsNotEmpty(result);
			Assert.AreEqual(2, result.Count);
			CollectionAssert.Contains(result, 2);
			CollectionAssert.Contains(result, 4);
		}

		[Test]
		public void SearchShouldBeCaseInsensitive()
		{
			var text = "aabb";
			var subText = "AA";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsNotEmpty(result);
			Assert.AreEqual(1, result.Count);
			CollectionAssert.Contains(result, 1);
		}

		[Test]
		public void ShouldReturnOneWhenLookingForSpaceInSaceA()
		{
			var text = " A";
			var subText = " ";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsNotEmpty(result);
			Assert.AreEqual(1, result.Count);
			CollectionAssert.Contains(result, 1);
		}

		[Test]
		public void ShouldReturnOneWhenLookingForJohnInJohnLennon()
		{
			var text = "John Lennon";
			var subText = "John";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsNotEmpty(result);
			Assert.AreEqual(1, result.Count);
			CollectionAssert.Contains(result, 1);
		}

		[Test]
		public void ShouldReturnEmptyWhenLookingForAAAInBBAA()
		{
			var text = "BBAA";
			var subText = "AAA";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsEmpty(result);
		}

		[Test]
		public void ShouldReturnEmptyWhenTextIsWhorterThanSubText()
		{
			var text = "AAA";
			var subText = "AAAA";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsEmpty(result);
		}

		[Test, Description("Ensure the proper handling of special chaacters(new lines, tabs...).")]
		public void ShouldReturnOneTwoWhenLookingForTabInATabA()
		{
			var text = "A\tA";
			var subText = "\t";

			var result = StringUtilities.GetSubTextPositions(text, subText);

			Assert.IsNotNull(result);
			CollectionAssert.IsNotEmpty(result);
			Assert.AreEqual(1, result.Count);
			CollectionAssert.Contains(result, 2);
		}

		[Test, Category("DataDriven")]
		[ExpectedException(typeof(ArgumentException))]
		[TestCase(null), TestCase("")]
		public void ShouldThrowArgumentExceptionWhenTextIsNullOrEmpty(string text)
		{
			var subText = "a";

			StringUtilities.GetSubTextPositions(text, subText);
		}

		[Test, Category("DataDriven")]
		[ExpectedException(typeof(ArgumentException))]
		[TestCase(null), TestCase("")]
		public void ShouldThrowArgumentExceptionWhenSubTextIsNullOrEmpty(string subText)
		{
			var text = "a";

			StringUtilities.GetSubTextPositions(text, subText);
		}

		[Test, Category("DataDriven")]
		[TestCaseSource(typeof(TestCasesRepository), nameof(TestCasesRepository.TestCases))]
		public ICollection<int> ShouldReturnExpectedResultsForTestCases(string text, string subText)
		{
			var result = StringUtilities.GetSubTextPositions(text, subText);
			return result;
		}

		#region Test cases data

		private class TestCasesRepository
		{
			public static IEnumerable TestCases
			{
				get
				{
					yield return
						new TestCaseData(
							"Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea",
							"Polly").Returns(new List<int> { 1, 26, 51 });

					yield return
						new TestCaseData(
							"Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea",
							"ll").Returns(new List<int> { 3, 28, 53, 78, 82 });

					yield return
						new TestCaseData(
							"Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea",
							"X").Returns(new List<int>());

					yield return
						new TestCaseData(
							"Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea",
							"Polx").Returns(new List<int>());

					yield return
						new TestCaseData(
							"11112",
							"12").Returns(new List<int> { 4 });

					yield return
						new TestCaseData(
							"aaaa",
							"aa").Returns(new List<int> { 1, 2, 3 });

					yield return
						new TestCaseData(
							"   ",
							"  ").Returns(new List<int> { 1, 2 });
				}
			}
		}

		#endregion
	}
}
