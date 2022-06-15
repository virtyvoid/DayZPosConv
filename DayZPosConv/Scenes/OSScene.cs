using System.Collections.Generic;
using Newtonsoft.Json;

namespace DayZPosConv.Scenes
{
    public class OSScene
    {
        [JsonProperty("Objects")]
        public List<SceneObject> Objects;

        public class SceneObject
        {
            public string name;
            public float[] pos, ypr;

            public static implicit operator SceneObject(DayZObject zObject) => 
                new SceneObject {name = zObject.Name, pos = zObject.Pos.AsArray(), ypr = zObject.Dir.AsArray()};
        }
        
        public static implicit operator OSScene(List<DayZObject> objects)
        {
            var scene = new OSScene {Objects = new List<SceneObject>()};
            foreach (var obj in objects) 
                scene.Objects.Add(obj);
            return scene;
        }
        
    }
}
