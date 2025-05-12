using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] data = {
                {"StdNum", "Name", "Math", "Science", "English"},
                {"1001", "Alice", "85", "90", "78"},
                {"1002", "Bob", "92", "88", "84"},
                {"1003", "Charlie", "79", "85", "88"},
                {"1004", "David", "94", "76", "92"},
                {"1005", "Eve", "72", "95", "89"}
            };
            // You can convert string to double by
            // double.Parse(str)


            int stdCount = data.GetLength(0) - 1;
            // ---------- TODO ----------
            double getScore(int x, int y)
            {
                string score = data[x, y];
                return double.Parse(score);
            }

            int getMax(int sub)
            {
                int max = 0;
                for (int i = 1; i < 6; ++i)
                {
                    if (getScore(i,sub) > max)
                    {
                        max = (int)getScore(i, sub);
                    }
                }
                return max;
            }

            int getMin(int sub)
            {
                int min = (int)getScore(1, sub);
                for (int i = 1; i < 6; ++i)
                {
                    if (getScore(i, sub) < min)
                    {
                       min = (int)getScore(i, sub);
                    }
                }
                return min;
            }

            int Total(int stu)
            {
                return (int)(getScore(stu, 2) + getScore(stu, 3) + getScore(stu, 4));
            }

            string getRank(int stu)
            {
                int r = 1;
                for (int i = 1; i <= stdCount; ++i)
                {
                    if (Total(stu) < Total(i))
                    {
                        r += 1;
                    }
                }
                switch (r)
                {
                    case 1:
                        return "1st";
                    case 2:
                        return "2nd";
                    case 3:
                        return "3rd";
                    case 4:
                        return "4th";
                    case 5:
                        return "5th";
                    default:
                        return "";
                }
            }

            double mathAvg = (getScore(1, 2) + getScore(2, 2) + getScore(3, 2) + getScore(4, 2) + getScore(5, 2)) / 5;
            double scienceAvg = (getScore(1, 3) + getScore(2, 3) + getScore(3, 3) + getScore(4, 3) + getScore(5, 3)) / 5;
            double englishAvg = (getScore(1, 4) + getScore(2, 4) + getScore(3, 4) + getScore(4, 4) + getScore(5, 4)) / 5;

            int mathMax = getMax(2); int mathMin = getMin(2);
            int scienceMax = getMax(3); int scienceMin = getMin(3);
            int englishMax = getMax(4); int englishMin = getMin(4);

            Console.WriteLine("Average Scores: ");
            Console.WriteLine("Math: "+ mathAvg.ToString());
            Console.WriteLine("Science: " + scienceAvg.ToString());
            Console.WriteLine("English: " + englishAvg.ToString());
            Console.WriteLine();

            Console.WriteLine("Max and min Scores: ");
            Console.WriteLine("Math: (" + mathMax.ToString() + ", " + mathMin.ToString() + ")");
            Console.WriteLine("Science: (" + scienceMax.ToString() + ", " + scienceMin.ToString() + ")");
            Console.WriteLine("English: (" + englishMax.ToString() + ", " + englishMin.ToString() + ")");
            Console.WriteLine();

            Console.WriteLine("Students rank by total scores");
            Console.WriteLine("Alice: " + getRank(1));
            Console.WriteLine("Bob: " + getRank(2));
            Console.WriteLine("Charlie: " + getRank(3));
            Console.WriteLine("David: " + getRank(4));
            Console.WriteLine("Eve: " + getRank(5));
            // --------------------
        }
    }
}

/* example output

Average Scores: 
Math: 84.40
Science: 86.80
English: 86.20

Max and min Scores: 
Math: (94, 72)
Science: (95, 76)
English: (92, 78)

Students rank by total scores:
Alice: 2nd
Bob: 5th
Charlie: 1st
David: 4th
Eve: 3rd

*/