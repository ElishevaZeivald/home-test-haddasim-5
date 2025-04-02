using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part_A_Finding_bugs
{
    internal class SplittingTheFile
    {
        //1
        const int LINES_PER_FILE = 1000;
        private const string OUTPUT_FOLDER = "split_logs"; 
        public static void SplitFile(string inputFile)
        {
            Directory.CreateDirectory(OUTPUT_FOLDER);

            using StreamReader reader = new StreamReader(inputFile);
            {
                int partNumber = 1;
                int numberOfLines = 0;
                string outputFile = Path.Combine(OUTPUT_FOLDER, $"{Path.GetFileName(inputFile)}.part{partNumber}.txt");
                StreamWriter writer = new StreamWriter(outputFile);

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (numberOfLines >= LINES_PER_FILE)
                    {
                        writer.Close();
                        partNumber++;
                        outputFile = Path.Combine(OUTPUT_FOLDER, $"{Path.GetFileName(inputFile)}.part{partNumber}.txt");
                        writer = new StreamWriter(outputFile);
                        numberOfLines = 0;
                    }
                    writer.WriteLine(line);
                    numberOfLines++;
                }
                writer.Close();
            }
            Console.WriteLine($"The file has been successfully split into a folder. '{OUTPUT_FOLDER}'");
        }
        //הפונקציה הנל עוברת בלולאה אחת על כל קובץ הלוג ולכן סיבוכיות זמן הריצה שלה היא
        //O(n)


        //2
        private const string LOG_FOLDER = "split_logs";
        private const int TOP_N_ERRORS = 5;
        public static void FindErrors()
        {
            Dictionary<string, int> errorsCount = new Dictionary<string, int>();
            foreach (string file in Directory.GetFiles(LOG_FOLDER, "*.part*"))
            {
                CountErrorsInFile(file, errorsCount);
            }
            var topErrors = errorsCount.OrderByDescending(kv => kv.Value).Take(TOP_N_ERRORS);

            Console.WriteLine($"{TOP_N_ERRORS} Most common error codes:");
            foreach (var error in topErrors)
            {
                Console.WriteLine($"{error.Key}: {error.Value} times");
            }
        }
        //מיון השגיאות במילון ע"פ שכיחות מרובה בפונקציה הנל זו פעולה שנעשית ע"י פקודת 
        //orderBy
        //שדורשת סיבוכיות ריצה של 
        //O(n log n)
        //ואחכ מבצעים חיתוך של חמשת הקודים עם שכיחות השגיאה הגבוהה ביותר שזה מתבצע בסיבוכיות 
        //O(1)
        //כי חותכים מספר מסוים וקטן של איברים מה
        //dictionary

        public static void CountErrorsInFile(string filePath, Dictionary<string, int> globalCounts)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string errorCode = ExtractErrorCode(line);

                    if (!string.IsNullOrEmpty(errorCode))
                    {
                        if (globalCounts.ContainsKey(errorCode))
                            globalCounts[errorCode]++;
                        else
                            globalCounts[errorCode] = 1;
                    }
                }
            }
        }
        //סיבוכיות הריצה של הפונקציות הנל:
        //פקודות הdictionary 
        //קוראות בתוך כל קובץ כל שורה פעם אחת בהנחה שיש 
        //שורות בקובץ ועל כן סיבוכיות הריצה היאm
        //O(m)


        public static string ExtractErrorCode(string logLine)
        {
            string keyword = "Error: ";
            int startIndex = logLine.IndexOf(keyword);
            if (startIndex != -1)
            {
                return logLine.Substring(startIndex + keyword.Length).Trim();
            }
            return null;
        }
    }
}
//סיבוכיות זמן הריצה הכוללת של כל הקוד הנל הינה:
//O(n) + O(1) + O(n log n) + O(m) = O(n log n)
//m < n
//משום שזה מספר השורות מתוך הקבצים הקטנים שיצרתי מהלוג הגדול
