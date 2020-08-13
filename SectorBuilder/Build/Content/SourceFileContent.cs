using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectorBuilder.Build.Content
{
    public class SourceFileContent : ISectorContent
    {
        private readonly ISourceFileContentProvider _provider;

        public SourceFileContent(ISourceFileContentProvider provider)
        {
            _provider = provider;
        }

        public string[] GetLines()
        {
            string[] lines = _provider.GetSourceFileLines();

            if (lines.Count() == 0)
            {
                return new string[] { "; <Empty Source File>" };
            }

            return lines;
        }
    }
}
