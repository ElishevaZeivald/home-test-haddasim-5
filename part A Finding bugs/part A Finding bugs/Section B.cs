using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Parquet;
using Parquet.Data;

namespace part_A
{
    internal class Section_B
    {
        //1
        public static bool IsValidDate(string inputFile)
        {
            //  using StreamReader reader = new StreamReader(inputFile);

            string[] lines = File.ReadAllLines(inputFile);
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');
                if (!DateTime.TryParse(parts[0], out DateTime date))
                {
                    Console.WriteLine("there is invalid date in that file");
                    lines[i] = lines[i+1];
                    i++;
                }
                return false;
            }

            Console.WriteLine("all the dates in that file are valid");
            return true;
        }


        public static string RemoveInvalidValue(string inputFile)
        {
            string newFile = "newFile";
            string[] lines = File.ReadAllLines(inputFile);
            /* for (int i = 1; i < lines.Length; i++)
             {*/
            string invalidWord = "NaN";
            var validLines = File.ReadAllLines(inputFile)
                         .Where(line =>
                         {
                             string[] parts = line.Split(',');
                             return parts.Length > 1 && double.TryParse(parts[1], out _);
                         })
                         .Where(line => !line.Contains(invalidWord))
                         .ToArray();
            string newFiles = Path.Combine(OUTPUT_FOLDER, $"{Path.GetFileName(newFile)}.csv");
            File.WriteAllLines(newFiles, validLines);
            return newFiles;

        }
        public static string IsExistValueEveryColumn(string inputFile)
        {
            using StreamReader reader = new StreamReader(inputFile);
            string[] lines = File.ReadAllLines(inputFile);
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');
                if (parts[1] == "")
                {
                    Console.WriteLine("there is column without value");
                    return "there is column without value";
                }
            }
            Console.WriteLine("all the columns in that file are valid");
            return "all the columns in that file are valid";

        }

        public static bool DuplicateDates(string inputFile)
        {
            if (IsValidDate(inputFile))
            {
                Dictionary<DateTime, int> dates = new Dictionary<DateTime, int>();
                string[] lines = File.ReadAllLines(inputFile.Trim());
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] parts = line.Split(",");
                    DateTime time = DateTime.Parse(parts[0]);
                    if (dates.ContainsKey(time))
                    {
                        dates[time]++;
                        // Console.WriteLine("there are duplicate dates in this file");
                        return true;
                    }
                    else
                    {
                        dates[time] = 1;
                    }
                }

            }
            //Console.WriteLine("there are not duplicate dates in that file");
            return false;
        }

        //2
        public static void AvgPerHour(string inputFile)
        {
            if (!DuplicateDates(inputFile))
            {
                double[,] valuesSum = new double[24, 32];
                double[,] counter = new double[24, 32];
                string[] lines = File.ReadAllLines(RemoveInvalidValue(inputFile));
                Dictionary<DateTime, double> avgValue = new Dictionary<DateTime, double>();
                int year = 0;
                int month = 0;
                DateTime time;
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] parts = line.Split(",");
                    time = DateTime.Parse(parts[0]);
                    if (year == 0) // נשלוף את השנה והחודש רק פעם אחת
                    {
                        year = time.Year;
                        month = time.Month;
                    }

                    int hour = time.Hour;
                    int day = time.Day;
                    valuesSum[hour, day] += double.Parse(parts[1]);
                    counter[hour, day]++;

                }

                // חישוב ממוצע לכל שעה ביום
                for (int day = 1; day <= 31; day++)
                {
                    for (int hour = 0; hour < 24; hour++)
                    {
                        if (counter[hour, day] > 0)  // אם יש לפחות ערך אחד עבור השעה הזו
                        {
                            double val = valuesSum[hour, day];
                            double count = counter[hour, day];
                            DateTime date = new DateTime(year, month, day, hour, 0, 0);
                            avgValue.Add(date, val / count);  // הוספת הממוצע לדיקציהרי
                        }
                    }
                }

                // הדפסת התוצאות של הממוצעים
                foreach (var a in avgValue)
                {
                    Console.WriteLine($"זמן התחלה: {a.Key}, ממוצע: {a.Value}");
                }
            }
        }


        private const string OUTPUT_FOLDER = "split_per_day";
        private const string OUTPUT_FILE = "avg_all.csv";

        public static void splitPerDay(string inputFile)
        {
            Directory.CreateDirectory(OUTPUT_FOLDER);

            string[] lines = File.ReadAllLines(RemoveInvalidValue(inputFile));
            var title = lines[0];
            var linesValue = lines.Skip(1);
            Dictionary<int, List<string>> data = new Dictionary<int, List<string>>();
            data = linesValue
               .GroupBy(d => DateTime.Parse(d.Split(",")[0]).Day)
               .ToDictionary(k => k.Key, v => v.ToList());
            //}
            foreach (var d in data)
            {
                int fileName = d.Key;
                List<string> fileValue = d.Value;

                string outputFile = Path.Combine(OUTPUT_FOLDER, $"{fileName}.csv");
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }
                File.WriteAllLines(outputFile, new[] { title }.Concat(fileValue));
            }

            string[] files = Directory.GetFiles(OUTPUT_FOLDER);
            using (StreamWriter writer = new StreamWriter(OUTPUT_FILE, false, Encoding.UTF8))

            // תופס את הפלט של Console.WriteLine
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw); // מכוון את הפלט ל-StringWriter במקום Console

                foreach (var file in files)
                {
                    AvgPerHour(file); // לא מחזיר ערך אבל מדפיס
                    string output = sw.ToString(); // תופס את הפלט שנשלח ל-Console
                    writer.WriteLine(output); // כותב לקובץ
                    sw.GetStringBuilder().Clear(); // מנקה את ה-StringWriter לפני הקריאה הבאה
                }

                // מחזיר את הפלט ל-Console הרגיל
                Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
            }
            //3
            //במקום לחכות עד לקבלת כל הקבצים ואז ביצוע כל הנל בעת זרימת הנתונים נשמור ערכים 
            //עבור כל שעה ובזמן אמת כשנכנס קובץ מחשבים את הממוצע עבור השעה הייעודית ומעדכנים
            //את הממוצע שלה ואז נשמור את הזמן האחרון ששודר בכדי לקבוע לאיזו שעה הערך שייך
            //ותוך כדי מחשבים ומעדכנים את הממוצע מיד עם קבלת כל ערך חדש

        }
    }
}



