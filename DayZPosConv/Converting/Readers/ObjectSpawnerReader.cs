using System.Collections.Generic;
using DayZPosConv.Scenes;
using Newtonsoft.Json;

namespace DayZPosConv.Converting
{
    public class ObjectSpawnerReader : IPosReader
    {
        public List<DayZObject> Read(string input)
        {
            var scene = (OSScene) JsonConvert.DeserializeObject(input, typeof(OSScene));
            var result = new List<DayZObject>();
            foreach (var sceneObject in scene.Objects) 
                result.Add(new DayZObject(sceneObject.name, sceneObject.pos, sceneObject.ypr));
            return result;
        }

        public bool IsSourceSuitable(string input) => input.Contains("\"Objects\"") && input.Contains("\"ypr\"");

        public override string ToString() => "Object Spawner (JSON)";
    }
}
