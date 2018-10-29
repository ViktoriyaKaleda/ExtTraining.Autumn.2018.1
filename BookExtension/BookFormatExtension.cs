using BookLibrary;
using System;

namespace BookExtension
{
	/// <summary>
	/// Class that provide editional formats for displaying information of book object.
	/// </summary>
	public class BookFormatExtension : IFormatProvider, ICustomFormatter
	{
		public static string DefaultFormat { get => "T"; }

		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			if (arg == null)
			{
				throw new ArgumentNullException(nameof(arg), "Value can not be undefined");
			}

			if (String.IsNullOrEmpty(format))
			{
				format = DefaultFormat;
			}

			var book = arg as Book;

			switch (format.ToUpper())
			{
				case "T":
					return $"Title: {book.Title}";

				case "A":
					return $"Author: {book.Author}";

				case "PH":
					return $"Publishing house: {book.PublishingHouse}";

				case "Y":
					return $"Year: {book.Year}";

				case "P":
					return $"Pages: {book.Pages}";

				case "PR":
					return $"Price: {book.Price}";

				default:
					throw new FormatException($"Unknown format: {format}.");
			}
		}

		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(Book))
				return new BookFormatExtension();
			
			return null;
		}
	}
}
