namespace DayZPosConv
{
    public readonly struct DayZObject
    {
        public readonly string Name;
        public readonly SimpleVector3 Pos;
        public readonly SimpleVector3 Dir;

        public DayZObject(string name, string pos, string dir = "0 0 0")
        {
            Name = name;
            Pos = pos;
            Dir = dir;
        }
        
        public DayZObject(string name, float[] pos, float[] dir)
        {
            Name = name;
            Pos = pos;
            Dir = dir;
        }
    }
}
