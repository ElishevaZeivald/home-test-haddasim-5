using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Console.WriteLine("there is invalid date in that file");
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
                          Console.WriteLine("there are duplicate dates at this file");
                        return true;
                    }
                    else
                    {
                        dates[time] = 1;
                    }
                }

            }
               Console.WriteLine("there are not duplicate dates in that file");
            return false;
        }

        //2
        public static void AvgPerHour(string inputFile)
        {
            if (!DuplicateDates(inputFile))
            {
                double[,] valuesSum = new double[24, 31];
                double[,] counter = new double[24, 31];
                string[] lines = File.ReadAllLines(RemoveInvalidValue(inputFile));
                Dictionary<DateTime, double> avgValue = new Dictionary<DateTime, double>();
                int year;
                int month;
                DateTime time;
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];
                    string[] parts = line.Split(",");
                    time = DateTime.Parse(parts[0]);
                    valuesSum[time.Hour, time.Day] += double.Parse(parts[1]);
                    counter[time.Hour, time.Day]++;

                }
                for (int i = 0, j = 1; j < 30; i++)
                {
                    for (int n = 1; n < 2; n++)
                    {
                        string line = lines[i];
                        string[] parts = line.Split(",");
                        time = DateTime.Parse(parts[0]);
                        year = time.Year;
                        month = time.Month;

                        /*   year = 2025;
                       month = 6;*/
                        DateTime date = new DateTime(year, month, j, i, 0, 0);
                        double val = valuesSum[i, j];
                        double count = counter[i, j];

                        avgValue.Add(date, val / count);
                        if (i == 23)
                        {
                            i = 0;
                            j++;
                        }
                    }
                }
                foreach (var a in avgValue)
                {
                    Console.WriteLine($"זמן התחלה:{a.Key},ממוצע:{a.Value}");
                }

            }
        }


        private const string OUTPUT_FOLDER = "split_per_day";

        public static void splitPerDay(string inputFile)
        {
            Directory.CreateDirectory(OUTPUT_FOLDER);

            string[] lines = File.ReadAllLines(RemoveInvalidValue(inputFile));
            var title = lines[0];
            var linesValue = lines.Skip(1);
            Dictionary<int, List<string>> data = new Dictionary<int, List<string>>();
           /* for (int i = 1; i < 2; i++)
            {*/
                //for (int j = 1; j < lines.Length; j++) { 
/*                string line = lines[i];
                string[] parts = line.Split(",");
                DateTime time = DateTime.Parse(parts[0]);
                int day = time.Day;*/
                data = linesValue
                   .GroupBy(d => DateTime.Parse(d.Split(",")[0]).Day)
                   .ToDictionary(k => k.Key, v => v.ToList());
                //}
                foreach (var d in data)
                {
                    int fileName = d.Key;
                    List<string> fileValue = d.Value;

                    string outputFile = Path.Combine(OUTPUT_FOLDER, $"{fileName}.csv");
                    File.WriteAllLines(outputFile, new[] { title }.Concat(fileValue));

                }

                string[] files = Directory.GetFiles(OUTPUT_FOLDER);
                string[] arr = new string[files.Length];
                for (int d=1;d<2;d++){
                    string fileValue = files[d];
                    AvgPerHour(fileValue);
                /*}*/

            }
        }
    }
}

