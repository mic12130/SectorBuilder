using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SectorBuilder.Build.Content
{
    public class SourceFileContentProvider : ISourceFileContentProvider
    {
        private readonly string _path;

        public SourceFileContentProvider(string path)
        {
            _path = path;
        }

        public string[] GetSourceFileLines()
        {
            string[] files = File.ReadAllLines(_path);

            return files;
        }
    }
}
