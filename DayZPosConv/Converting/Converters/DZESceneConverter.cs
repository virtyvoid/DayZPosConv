using System;
using System.Collections.Generic;
using DayZPosConv.Scenes;
using Newtonsoft.Json;

namespace DayZPosConv.Converting
{
    public class DZESceneConverter : IPosConverter
    {
        public string Convert(in DayZObject @object) => throw new NotImplementedException();

        public string Convert(List<DayZObject> objects)
        {
            DZEScene.IdCounter = 0;
            return JsonConvert.SerializeObject((DZEScene) objects, Formatting.Indented);
        } 

        public bool IsBatchConverter() => true;

        public override string ToString() => "DayZ Editor Scene (JSON)";
    }
}
