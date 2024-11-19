namespace RadarLibrary
{
    public class Models
    {
        public class RadarResponse
        {
            public List<RadarTarget>? Targets { get; set; }
            public long Timestamp { get; set; }
            public bool IsOnline { get; set; }
            public string? LastError { get; set; }
        }

        public class RadarTarget
        {
            public int Id { get; set; }
            public double Distance { get; set; }
            public double Angle { get; set; }
            public double Speed { get; set; }
            public double Strenght { get; set; }
        }
    }
}
