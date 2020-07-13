using System;

namespace DayZPosConv
{
    public readonly struct SimpleVector3
    {
        public readonly float x, y, z;

        public SimpleVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public SimpleVector3(float[] xyz)
        {
            x = xyz[0];
            y = xyz[1];
            z = xyz[2];
        }

        public static implicit operator SimpleVector3(float[] xyz) => new SimpleVector3(xyz);

        public static implicit operator SimpleVector3(string str)
        {
            var temp = str.Trim().Split(new []{',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            return new SimpleVector3(Convert.ToSingle(temp[0]), Convert.ToSingle(temp[1]), Convert.ToSingle(temp[2]));
        }

        public float[] AsArray() => new[] { x, y, z };

        public override string ToString() => $"{x:F6} {y:F6} {z:F6}";

        public string ToStringWithCommas() => $"{x:F6}, {y:F6}, {z:F6}";
    }
}
