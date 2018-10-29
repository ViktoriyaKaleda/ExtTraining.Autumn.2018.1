using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IFormattable
	{
        public string Title { get; set; }

		public string Author { get; set; }

		public string Year { get; set; }

		public string PublishingHouse { get; set; }

		public string Edition { get; set; }

		public string Pages { get; set; }

		public string Price { get; set; }

		private static string DefaultFormat { get => "AT"; }

		/// <summary>
		/// Returns string representation of the book.
		/// </summary>
		/// <param name="format"></param>
		/// <param name="formatProvider"></param>
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
