using System;
using System.Collections.Generic;
using System.Text;

namespace SectorBuilder.Config
{
    public class JsonParserException : Exception
    {
        public string Path { get; }
        public int LineNumber { get; }
        public int LinePosition { get; }

        public JsonParserException()
        {
        }

        public JsonParserException(string message)
            : base(message)
        {
        }

        public JsonParserException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public JsonParserException(string message, string path, int lineNumber, int linePosition, Exception inner)
            : base(message, inner)
        {
            Path = path;
            LineNumber = lineNumber;
            LinePosition = linePosition;
        }
    }
}
