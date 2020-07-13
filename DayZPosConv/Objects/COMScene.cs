using System.Collections.Generic;
using Newtonsoft.Json;

namespace DayZPosConv
{
    public class COMScene
    {
        public string name;
        [JsonProperty("m_SceneObjects")]
        public List<SceneObject> objects;

        public class SceneObject
        {
            public string param1;
            public float[] param2, param3;

            public static implicit operator SceneObject(DayZObject zObject) => 
                new SceneObject {param1 = zObject.Name, param2 = zObject.Pos.AsArray(), param3 = zObject.Dir.AsArray()};
        }
        
        public static implicit operator COMScene(List<DayZObject> objects)
        {
            var scene = new COMScene {name = "latest", objects = new List<SceneObject>()};
            foreach (var obj in objects) 
                scene.objects.Add(obj);
            return scene;
        }
        
    }
}
