using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DayZPosConv.Converting
{
    public class TraderPosReader : IPosReader
    {
        private static readonly Regex Expr =
            new Regex(
                @"\s*?(?<!//\s*?)<Object>\s*([^\n\t\s/]*).*\n\s*?<ObjectPosition>\s*([^\n/]*).*\n\s*?<ObjectOrientation>\s*([^\n/]*)", //$
                RegexOptions.Compiled | RegexOptions.Multiline);
        public List<DayZObject> Read(string input)
        {
            var matcher = Expr.Match(input);
            var result = new List<DayZObject>();
            while (matcher.Success)
            {
                result.Add(new DayZObject(matcher.Groups[1].Value, matcher.Groups[2].Value, matcher.Groups[3].Value));
                matcher = matcher.NextMatch();
            }
            return result;
        }

        public bool IsSourceSuitable(string input) => input.Contains("<ObjectOrientation>");

        public override string ToString() => "Trader Objects";
    }
}
