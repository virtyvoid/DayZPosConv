using System.Collections.Generic;
using System.Text;

namespace DayZPosConv.Converting
{
    public class TraderPosConverter : IPosConverter
    {
        public string Convert(in DayZObject @object)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<Object>\t\t\t{@object.Name}");
            sb.AppendLine($"<ObjectPosition>\t{@object.Pos.ToStringWithCommas()}");
            sb.AppendLine($"<ObjectOrientation>\t{@object.Dir.ToStringWithCommas()}");
            sb.AppendLine();
            return sb.ToString();
        }

        public string Convert(List<DayZObject> objects) => throw new System.NotImplementedException();

        public bool IsBatchConverter() => false;

        public override string ToString() => "Trader Objects";
    }
}
