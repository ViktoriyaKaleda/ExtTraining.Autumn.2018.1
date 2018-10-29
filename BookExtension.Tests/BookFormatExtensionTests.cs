using System;
using BookLibrary;
using NUnit.Framework;

namespace BookExtension.Tests
{
	[TestFixture]
    public class BookFormatExtensionTests
    {
		[TestCase("A", "C# in Depth", "Jon Skeet", "2019", "Author: Jon Skeet")]
		[TestCase("T", "C# in Depth", "Jon Skeet", "2019", "Title: C# in Depth")]
		[TestCase("Y", "C# in Depth", "Jon Skeet", "2019", "Year: 2019")]
		public void ToString_ValidData_ValidResult(string format, string title, string author, string year, string expectedResult)
		{
			var book = new Book()
			{
				Author = author,
				Title = title,
				Year = year
			};

			Assert.That(book.ToString(format, new BookFormatExtension()), Is.EqualTo(expectedResult));
		}

		[TestCase("C# in Depth", "Jon Skeet", "2019", "Author: Jon Skeet, Title: C# in Depth, Year: 2019")]
		public void Format_ValidData_ValidResult(string title, string author, string year, string expectedResult)
		{
			var book = new Book()
			{
				Author = author,
				Title = title,
				Year = year
			};
			Assert.That(String.Format(new BookFormatExtension(), "{0:A}, {0:T}, {0:Y}", book), Is.EqualTo(expectedResult));
		}
	}
}
