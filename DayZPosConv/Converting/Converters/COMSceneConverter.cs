using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DayZPosConv.Converting
{
    public class COMSceneConverter : IPosConverter
    {
        public string Convert(in DayZObject @object) => throw new NotImplementedException();

        public string Convert(List<DayZObject> objects) => JsonConvert.SerializeObject((COMScene) objects, Formatting.Indented);

        public bool IsBatchConverter() => true;

        public override string ToString() => "COM Scene (JSON)";
    }
}
