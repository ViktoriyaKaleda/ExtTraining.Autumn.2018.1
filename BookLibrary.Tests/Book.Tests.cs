using System;
using System.Globalization;
using NUnit.Framework;

namespace BookLibrary.Tests
{
	[TestFixture]
    public class BookTests
    {
		[TestCase("F", "C# in Depth", "Jon Skeet", "Manning", "2019", "4", "500", "200",
			"Jon Skeet, C# in Depth, 2019, \"Manning\", edition: 4, pages: 500, price: 200")]
		[TestCase("ATYP", "C# in Depth", "Jon Skeet", "Manning", "2019", "4", "500", "200",
			"Jon Skeet, C# in Depth, 2019, \"Manning\"")]
		[TestCase("ATY", "C# in Depth", "Jon Skeet", "Manning", "2019", "4", "500", "200",
			"Jon Skeet, C# in Depth, 2019")]
		[TestCase("AT", "C# in Depth", "Jon Skeet", "Manning", "2019", "4", "500", "200",
			"Jon Skeet, C# in Depth")]
		[TestCase("AYP", "C# in Depth", "Jon Skeet", "Manning", "2019", "4", "500", "200",
			"Jon Skeet, 2019, \"Manning\"")]
		[TestCase(null, "C# in Depth", "Jon Skeet", "Manning", "2019", "4", "500", "200",
			"Jon Skeet, C# in Depth")]
		public void ToString_ValidFormat_ValidResult(string format, string title, string author, string publishingHouse,
			string year, string edition, string pages, string price, string expectedResult)
		{
			var book = new Book()
			{
				Title = title,
				Author = author,
				PublishingHouse = publishingHouse,
				Year = year,
				Edition = edition,
				Pages = pages,
				Price = price,
			};

			Assert.That(book.ToString(format), Is.EqualTo(expectedResult));
		}
	}
}
