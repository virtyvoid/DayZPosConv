using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DayZPosConv.Converting
{
    public class COMExportExpansionReader : IPosReader
    {
        private static readonly Regex Splitter = new Regex(@"(?:\r\n|\n)\b", RegexOptions.Compiled);
        public List<DayZObject> Read(string input)
        {
            //var temp = input.Split(new[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            var result = new List<DayZObject>();
            var temp = Splitter.Split(input);
            foreach (var line in temp)
            {
                var objTemp = line.Split('|');
                result.Add(new DayZObject(objTemp[0], objTemp[1], objTemp[2]));
            }
            return result;
        }

        public bool IsSourceSuitable(string input) => Regex.IsMatch(input, @"^.*\|.*\|.*");

        public override string ToString() => "COM Export (Expansion Map)";
    }
}
