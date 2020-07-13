using System.Collections.Generic;

namespace DayZPosConv.Converting
{
    internal interface IPosReader
    {
        List<DayZObject> Read(string input);
        bool IsSourceSuitable(string input);
    }
}
