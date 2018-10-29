using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class Parser
    {
		/// <summary>
		/// Min number system in which can be letters.
		/// </summary>
		private const int minBaseForLetters = 11;

		/// <summary>
		/// Number subtraction which from digit symbol return integer digit.
		/// </summary>
		private const int encodingShift = 55;

		/// <summary>
		/// Converts number to passed number system.
		/// </summary>
		/// <param name="source">String that contains number representation.</param>
		/// <param name="base">The number system.</param>
		/// <returns>Number in passed scale of notation.</returns>
        public static int ToDecimal(this string source, int @base)
        {
			if (source == null)
				throw new ArgumentNullException(nameof(source), "The value can not be undefind.");

			if (@base < 2 || @base > 16)
				throw new ArgumentOutOfRangeException(nameof(@base), "The value must be between 2 and 16.");

			int result = 0;
			for (int i = source.Length - 1, degree = 0; i >= 0; i--, degree++)
			{
				checked
				{
					if (Char.IsDigit(source[i]))
					{
						int digit = (int)Char.GetNumericValue(source[i]);
						if (digit >= @base)
							throw new ArgumentException("Invalid string representation of the number.", nameof(source));

						result += (int)Math.Pow(@base, degree) * digit;
					}
					else
					{
						if (@base < minBaseForLetters || ToUpper(source[i]) > GetMaxValidLetter(@base))
							throw new ArgumentException("Invalid string representation of the number.", nameof(source));

						result += (int)Math.Pow(@base, degree) * (ToUpper(source[i]) - encodingShift);
					}
				}	
			}
				
			return result;
		}

		/// <summary>
		/// Converts char symbol to upper case.
		/// </summary>
		/// <param name="c">The symbol to convert.</param>
		/// <returns>The symbol in upper case.</returns>
		private static char ToUpper(char c)
		{
			return c.ToString().ToUpper().ToCharArray()[0];
		}

		/// <summary>
		/// Returns the max valid letter for passed number system.
		/// </summary>
		/// <param name="base">The number system.</param>
		/// <returns>The max valid letter for passed scale of notation.</returns>
		private static char GetMaxValidLetter(int @base)
		{
			switch(@base)
			{
				case 11:
					return 'A';

				case 12:
					return 'B';

				case 13:
					return 'C';

				case 14:
					return 'D';

				case 15:
					return 'E';

				case 16:
					return 'F';
			}
			throw new ArgumentException(nameof(@base));
		}
    }
}
