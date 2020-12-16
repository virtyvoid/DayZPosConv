using System.Collections.Generic;
using DayZPosConv.Scenes;
using Newtonsoft.Json;

namespace DayZPosConv.Converting
{
    public class DZESceneReader : IPosReader
    {
        public List<DayZObject> Read(string input)
        {
            var scene = (DZEScene) JsonConvert.DeserializeObject(input, typeof(DZEScene));
            var result = new List<DayZObject>();
            foreach (var sceneObject in scene.Objects) 
                result.Add(new DayZObject(sceneObject.Type, sceneObject.Position, sceneObject.Orientation));
            return result;
        }

        public bool IsSourceSuitable(string input) => input.Contains("\"EditorObjects\":");

        public override string ToString() => "DayZ Editor Scene (JSON)";
    }
}
