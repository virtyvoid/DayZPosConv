using System;
using System.Collections.Generic;
using DayZPosConv.Scenes;
using Newtonsoft.Json;

namespace DayZPosConv.Converting
{
    public class ObjectSpawnerConverter : IPosConverter
    {
        public string Convert(in DayZObject @object) => throw new NotImplementedException();

        public string Convert(List<DayZObject> objects) => JsonConvert.SerializeObject((OSScene) objects, Formatting.Indented);

        public bool IsBatchConverter() => true;

        public override string ToString() => "Object Spawner (JSON)";
    }
}
