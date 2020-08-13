using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectorBuilder.Build.Content
{
    public class SourceFileInfoContent : ISectorContent
    {
        private readonly string _path;

        public SourceFileInfoContent(string path)
        {
            if (path.Length == 0)
            {
                throw new ArgumentException("Source file path cannot be null");
            }

            _path = path;
        }

        public string[] GetLines()
        {
            return new string[]
            {
                "; --------------------------------------------------",
                "; SOURCE: " + _path,
                "; --------------------------------------------------"
            };
        }
    }
}
