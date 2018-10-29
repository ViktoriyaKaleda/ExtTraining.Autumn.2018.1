using System;
using System.Globalization;

namespace BookLibrary
{
	/// <summary>
	/// Class that contains book information. All fields are of string type by task condition.
	/// </summary>
	public class Book : IFormattable
	{
		/// <summary>
		/// The book title.
		/// </summary>
        public string Title { get; set; }

		/// <summary>
		/// The book author.
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// The book publishing year.
		/// </summary>
		public string Year { get; set; }

		/// <summary>
		/// The book publishing house.
		/// </summary>
		public string PublishingHouse { get; set; }

		/// <summary>
		/// The book edition.
		/// </summary>
		public string Edition { get; set; }

		/// <summary>
		/// The number of pages.
		/// </summary>
		public string Pages { get; set; }

		/// <summary>
		/// The book price.
		/// </summary>
		public string Price { get; set; }

		/// <summary>
		/// Default format for ToString method.
		/// </summary>
		private static string DefaultFormat { get => "AT"; }

		/// <summary>
		/// Returns string representation of the book.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <returns>String representation of the book.</returns>
		public string ToString(string format, IFormatProvider formatProvider = null)
		{
			if (format == null)
				format = DefaultFormat;

			if (formatProvider != null)
			{
				ICustomFormatter formatter = formatProvider.GetFormat(this.GetType()) as ICustomFormatter;

				if (formatter != null)
					return formatter.Format(format, this, formatProvider); 
			}

			if (formatProvider == null)
			{
				formatProvider = CultureInfo.CurrentCulture;
			}

			switch (format.ToUpper())
			{
				case "F":
					return $"{Author}, {Title}, {Year}, \"{PublishingHouse}\", edition: {Edition}, pages: {Pages}, price: {Price}";
					
				case "ATYP":
					return $"{Author}, {Title}, {Year}, \"{PublishingHouse}\"";

				case "ATY":
					return $"{Author}, {Title}, {Year}";

				case "AT":
					return $"{Author}, {Title}";

				case "AYP":
					return $"{Author}, {Year}, \"{PublishingHouse}\"";

				default:
					throw new FormatException($"Unknown format: {format}.");
			}
		}

		/// <summary>
		/// Returns string representation of the book.
		/// </summary>
		/// <returns>String representation of the book.</returns>
		public override string ToString()
		{
			return ToString(DefaultFormat);
		}
	}
}
