using System;
using System.Linq;

namespace Services.Services.Objects
{
    public class HighScoreItem
    {
        private const char Spliter = ';';
        public HighScoreItem(string scoreLine)
        {
            var data = scoreLine.Split(new[] { Spliter,'\n','\r' }, StringSplitOptions.RemoveEmptyEntries);
            Name = data.FirstOrDefault();
            Score = Int32.Parse(data.LastOrDefault()??"0");
        }

        public string Name { get; private set; }
        public int Score { get; private set; }
        public override string ToString()
        {
            return Name + Spliter + Score + "\n\r";
        }
    }
}
