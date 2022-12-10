using System.Text.RegularExpressions;

namespace ConsoleConverter
{
    internal class WordsToNumbers
    {

        private static Dictionary<string, string> numberTable = new Dictionary<string, string>{
        {",",""},{"and", ""},{"zero","0"},{"one","1"},{"two","2"},{"three","3"},{"four","4"},{"five","5"},{"six","6"},
        {"seven","7"},{"eight","8"},{"nine","9"},{"ten","10"},{"eleven","11"},{"twelve","12"},
        {"thirteen","13"},{"fourteen","14"},{"fifteen","15"},{"sixteen","16"},{"seventeen","17"},
        {"eighteen","18"},{"nineteen","19"},{"twenty","20"},{"thirty","30"},{"forty","40"},
        {"fifty","50"},{"sixty","60"},{"seventy","70"},{"eighty","80"},{"ninety","90"},
        {"hundred","100"},{"thousand","1000"},{"million","1000000"},
        {"billion","1000000000"},{"trillion","1000000000000"}
    };

        public static long ConvertToNumbers(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                    .Select(m => m.Value.ToLowerInvariant())
                    .Where(v => numberTable.ContainsKey(v))
                    .Select(v => numberTable[v]);
            long acc = 0, total = 0L;
            foreach (var n in numbers)
            {
                Int64 num = Convert.ToInt64(n);
                if (num >= 1000000000)
                {
                    total += acc * num;
                    acc = 0;
                }
                if (num >= 1000000)
                {
                    total += acc * num;
                    acc = 0;
                }
                if (num >= 1000)
                {
                    total += acc * num;
                    acc = 0;
                }

                else if (num >= 100)
                {
                    acc *= num;
                }
                else acc += num;
            }
            return (total + acc) * (numberString.StartsWith("minus",
                    StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }
    }

}
