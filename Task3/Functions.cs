using System;
using System.IO;

namespace Task3
{
    class Functions
    {
        /// <summary>
        /// Method where program starts working.
        /// </summary>
        /// <param name="russianPath"> Path for russian sentence set. </param>
        /// <param name="englishPath"> Path for english sentence set. </param>
        public static void Start(string russianPath, string englishPath)
        {
            // Reading files.
            string[] russian = File.ReadAllLines(russianPath);
            string[] english = File.ReadAllLines(englishPath);

            for (int i = 0; i < russian.Length; i++)
            {
                // Calculating Petrenko's index for russian sentence.
                double indexRu = Functions.CalculatePetrenkoIndex(russian[i]);
                Console.WriteLine($"Russian sentence: {russian[i]}");
                Console.WriteLine($"Petrenko index: {indexRu}");
                for (int j = 0; j < english.Length; j++)
                {
                    if (indexRu == FindIndexForEnglish(english[j])) // Checking if it's equal to russian index.
                    {
                        Console.WriteLine($"Equal index english sentence: {english[j]}\n");
                    }
                    else if (j == english.Length - 1) // If there is no equal index sentence.
                    {
                        Console.WriteLine("There is no equal english sentence :(\n");
                    }
                }
            }
        }

        /// <summary>
        /// Method to find Petrenko's index of english sentence.
        /// </summary>
        /// <param name="text"> Text. </param>
        /// <returns></returns>
        public static double FindIndexForEnglish(string text)
        {
            // Splitting sentence to body text and comment.
            string[] parts = text.Split('|');
            double output = 0;

            // Finding Petrenko index for them.
            foreach (var item in parts)
            {
                output += Functions.CalculatePetrenkoIndex(item);
            }

            // Returning result.
            return output;
        }

        /// <summary>
        /// Method to remove unnecessary charecters from text.
        /// </summary>
        /// <param name="text"> Text. </param>
        /// <returns></returns>
        public static string RemoveUnnecessarySymbols(string text)
        {
            return String.Join(string.Empty, text.Split(new char[] { ' ', '.', '!', '?', ',', '-', '\'' },
                StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Method to calculate Index of Petrenko.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static double CalculatePetrenkoIndex(string text)
        {
            // Removing unnecessary symbols.
            text = Functions.RemoveUnnecessarySymbols(text);
            double output = 0;
            int num = text.Length;

            // Calculating index.
            output += (num / 2) * num;
            output += num * 0.5;
            output *= num;

            // Returning result.
            return output;
        }
    }
}
