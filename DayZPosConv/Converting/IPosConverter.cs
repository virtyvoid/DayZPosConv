using System.Collections.Generic;

namespace DayZPosConv.Converting
{
    internal interface IPosConverter
    {
        string Convert(in DayZObject @object);
        string Convert(List<DayZObject> objects);
        bool IsBatchConverter();
    }
}
