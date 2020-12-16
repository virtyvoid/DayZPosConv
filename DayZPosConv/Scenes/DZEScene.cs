using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DayZPosConv.Scenes
{
    public class DZEScene
    {
        [JsonIgnore]
        public static int IdCounter;
        
        [JsonProperty("EditorObjects", Order = 3)]
        public List<SceneObject> Objects;
        // Dummy
        [JsonProperty(Order = 1)]
        public string MapName;
        [JsonProperty(Order = 2)]
        public float[] CameraPosition;
        [JsonProperty(Order = 9999)]
        public object[] DeletedObjects;

        public DZEScene()
        {
            // Dummy data
            MapName = "ChernarusPlus";
            CameraPosition = new float[3];
            DeletedObjects = new object[0];
        }

        public class SceneObject
        {
            public int m_Id;
            public string Type;
            public string DisplayName;
            public float[] Position, Orientation;
            
            // Dummy
            public float Scale;
            public int Flags;

            public SceneObject()
            {
                // Dummy data
                Scale = 1f;
                Flags = 30; // ALL
            }

            public static implicit operator SceneObject(DayZObject zObject) => 
                new SceneObject {m_Id = ++IdCounter, Type = zObject.Name, DisplayName = zObject.Name, 
                    Position = zObject.Pos.AsArray(), Orientation = zObject.Dir.AsArray()};
        }
        
        public static implicit operator DZEScene(List<DayZObject> objects)
        {
            var scene = new DZEScene {Objects = new List<SceneObject>()};
            foreach (var obj in objects) 
                scene.Objects.Add(obj);
            scene.CameraPosition[0] = objects.Average(o => o.Pos.x);
            scene.CameraPosition[1] = objects.Average(o => o.Pos.y);
            scene.CameraPosition[2] = objects.Average(o => o.Pos.z);
            return scene;
        }
        
    }
}
