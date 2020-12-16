using System.Collections.Generic;
using DayZPosConv.Scenes;
using Newtonsoft.Json;

namespace DayZPosConv.Converting
{
    public class COMSceneReader : IPosReader
    {
        public List<DayZObject> Read(string input)
        {
            var scene = (COMScene) JsonConvert.DeserializeObject(input, typeof(COMScene));
            var result = new List<DayZObject>();
            foreach (var sceneObject in scene.Objects) 
                result.Add(new DayZObject(sceneObject.param1, sceneObject.param2, sceneObject.param3));
            return result;
        }

        public bool IsSourceSuitable(string input) => input.Contains("\"m_SceneObjects\"");

        public override string ToString() => "COM Scene (JSON)";
    }
}
