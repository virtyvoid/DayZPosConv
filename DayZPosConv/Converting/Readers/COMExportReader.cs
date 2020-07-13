using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DayZPosConv.Converting
{
    public class COMExportReader : IPosReader
    {
        private static readonly Regex Expr = new Regex(@"SpawnObject\(\s*?""(.*)"",\s*?""(.*)"",\s*?""(.*)""\s*?\);",
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

        public bool IsSourceSuitable(string input) => input.Contains("SpawnObject(");

        public override string ToString() => "COM Export (init.c)";
    }
}
