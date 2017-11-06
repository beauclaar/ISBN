using System;

namespace ISBN
{
    class Converter
    {
        public static string ConvertTo10(string isbn13)
        {
            string isbn10 = string.Empty;
            long temp;

            if (!(string.IsNullOrEmpty(isbn13) && isbn13.Length == 13 && long.TryParse(isbn13, out temp)))
            {
                isbn10 = isbn13.Substring(3, 9);
                int sum = 0;
                for (int i = 0; i <= 8; i++)
                {
                    sum += Int32.Parse(isbn10[i].ToString()) * (i + 1);
                }
                int result = sum % 11;
                char checkDigit = (result > 9) ? 'X' : result.ToString()[0];
                isbn10 += checkDigit;
            }

            return isbn10;
        }

        public static string ConvertTo13(string isbn10)
        {
            string isbn13 = string.Empty;
            long temp;
            if (!(string.IsNullOrEmpty(isbn10) && isbn10.Length == 10 && long.TryParse(isbn10.Substring(0, 9), out temp)))
            {
                int result = 0;
                isbn13 = "978" + isbn10.Substring(0, 9);
                for (int i = 0; i < isbn13.Length; i++)
                {
                    result += int.Parse(isbn13[i].ToString()) * ((i % 2 == 0) ? 1 : 3);
                }
                int checkDigit = (10 - (result % 10)) % 10;
                isbn13 += checkDigit.ToString();
            }
            return isbn13;
        }
    }
}
