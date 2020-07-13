using System;
using System.Collections.Generic;

namespace DayZPosConv.Converting
{
    public class COMExportExpansionPosConverter : IPosConverter
    {
        public string Convert(in DayZObject @object) => $"{@object.Name}|{@object.Pos}|{@object.Dir}";
        
        public string Convert(List<DayZObject> objects) => throw new NotImplementedException();
        
        public bool IsBatchConverter() => false;

        public override string ToString() => "COM Export (Expansion Map)";
    }
}
