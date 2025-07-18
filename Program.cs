namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "hwfdawhwhcoomddfgwdc";
            var matches = FindVietnameseTelexAccents(input);
            Console.WriteLine($"{matches.Count} ({string.Join(", ", matches)})");
            // Kết quả: 6 (w, aw, w, oo, dd, w)
        }

        static List<string> FindVietnameseTelexAccents(string s)
        {
            var twoChar = new HashSet<string> { "aw", "aa", "dd", "ee", "oo", "ow" };
            var matches = new List<string>();

            for (int i = 0; i < s.Length;)
            {
                // ưu tiên 2 ký tự
                if (i + 1 < s.Length)
                {
                    string pair = s.Substring(i, 2);
                    if (twoChar.Contains(pair))
                    {
                        matches.Add(pair);
                        i += 2;
                        continue;
                    }
                }

                // ký tự đơn 'w' → ư
                if (s[i] == 'w')
                {
                    matches.Add("w");
                    i += 1;
                }
                else
                {
                    i += 1;
                }
            }

            return matches;
        }
    }
}
