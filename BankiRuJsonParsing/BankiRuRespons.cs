namespace BankiRuJsonParsing
{
    public class BankiRuRespons
    {
        public Candles candles { get; set; }
    }

    public class Candles
    {
        public Metadata metadata { get; set; }
        public string[] columns { get; set; }
        public object[][] data { get; set; }
    }

    public class Metadata
    {
        public Open open { get; set; }
        public Close close { get; set; }
        public High high { get; set; }
        public Low low { get; set; }
        public Value value { get; set; }
        public Volume volume { get; set; }
        public Begin begin { get; set; }
        public End end { get; set; }
    }

    public class Open
    {
        public string type { get; set; }
    }

    public class Close
    {
        public string type { get; set; }
    }

    public class High
    {
        public string type { get; set; }
    }

    public class Low
    {
        public string type { get; set; }
    }

    public class Value
    {
        public string type { get; set; }
    }

    public class Volume
    {
        public string type { get; set; }
    }

    public class Begin
    {
        public string type { get; set; }
        public int bytes { get; set; }
        public int max_size { get; set; }
    }

    public class End
    {
        public string type { get; set; }
        public int bytes { get; set; }
        public int max_size { get; set; }
    }

}