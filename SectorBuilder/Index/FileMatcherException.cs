using System;
using System.Collections.Generic;
using System.Text;

namespace SectorBuilder.Index
{
    public class FileMatcherException : Exception
    {
        public string Dir { get; }
        public string Pattern { get; }

        public FileMatcherException()
        {
        }

        public FileMatcherException(string message)
            : base(message)
        {
        }

        public FileMatcherException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public FileMatcherException(string message, string dir, string pattern, Exception inner)
            : base(message, inner)
        {
            Dir = dir;
            Pattern = pattern;
        }
    }
}
