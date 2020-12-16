using System.Collections.Generic;
using Newtonsoft.Json;

namespace DayZPosConv.Scenes
{
    public class COMScene
    {
        // Dummy
        public string name;
        [JsonProperty("m_SceneObjects")]
        public List<SceneObject> Objects;

        public COMScene()
        {
            // Dummy data
            name = "latest";
        }

        public class SceneObject
        {
            public string param1;
            public float[] param2, param3;

            public static implicit operator SceneObject(DayZObject zObject) => 
                new SceneObject {param1 = zObject.Name, param2 = zObject.Pos.AsArray(), param3 = zObject.Dir.AsArray()};
        }
        
        public static implicit operator COMScene(List<DayZObject> objects)
        {
            var scene = new COMScene {Objects = new List<SceneObject>()};
            foreach (var obj in objects) 
                scene.Objects.Add(obj);
            return scene;
        }
        
    }
}
