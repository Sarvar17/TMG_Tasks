using System;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace Task1
{
    class Functions
    {
        /// <summary>
        /// Method to count number of words in text.
        /// </summary>
        /// <param name="text"> Text. </param>
        /// <returns></returns>
        public static int countWords(string text)
        {
            return text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Method to count number of vowels in text.
        /// </summary>
        /// <param name="text"> Text. </param>
        /// <returns></returns>
        public static int countVowel(string text)
        {
            // Initializing english and russian vowels.
            char[] vowels = { 'a', 'e', 'u', 'i', 'o', 'а', 'о', 'у', 'ы', 'э', 'я', 'ё', 'ю', 'и', 'е' };

            return text.ToLower().Count(x => vowels.Contains(x));
        }

        /// <summary>
        /// Method to get response of site;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T getResponse<T>(int id)
        {
            using (var wc = new WebClient())
            {
                var json_data = string.Empty;
                try
                {
                    // Adding a header.
                    wc.Headers.Add("TMG-Api-Key", "0J/RgNC40LLQtdGC0LjQutC4IQ==");
                    // Downloading json string.
                    json_data = wc.DownloadString($"http://tmgwebtest.azurewebsites.net/api/textstrings/{id}");
                }
                catch (Exception e)  // Catching exception.
                {
                    throw new ArgumentException(e.Message);
                }

                // returning deserialized json data if it is not null or empty.
                return JsonSerializer.Deserialize<T>(json_data);
            }
        }

        /// <summary>
        /// Method to make one line multiline;
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string makeMultiline(string text)
        {
            string result = string.Empty;

            while (text.Length > 55)
            {
                result += text.Substring(0, 55) + "\n";
                text = text.Substring(55, text.Length - 55);
            }

            result += text;

            return result;
        }
    }
}
