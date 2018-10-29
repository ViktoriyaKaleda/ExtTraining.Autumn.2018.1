﻿using BookLibrary;
using System;

namespace BookExtension
{
	/// <summary>
	/// Class that provides editional formats for displaying information of book object.
	/// </summary>
	public class BookFormatExtension : IFormatProvider, ICustomFormatter
	{
		/// <summary>
		/// Default format for book string representation.
		/// </summary>
		public static string DefaultFormat { get => "T"; }

		/// <summary>
		/// Method that supports custom formating of the value of a book.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="arg">The vslue for format, must be of type Book.</param>
		/// <param name="formatProvider">The fprmat provider.</param>
		/// <returns>Formating string.</returns>
		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			if (arg == null)
				throw new ArgumentNullException(nameof(arg), "Value can not be undefined");

			if (!(arg is Book))
				throw new ArgumentException("Value must be of type Book.", nameof(arg));

			if (String.IsNullOrEmpty(format))
				format = DefaultFormat;

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

		/// <summary>
		/// Returns current format provider.
		/// </summary>
		/// <param name="formatType">The format type.</param>
		/// <returns>Current format provider.</returns>
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(Book))
				return new BookFormatExtension();
			
			return null;
		}
	}
}
