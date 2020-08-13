using System;
using System.Collections.Generic;
using System.Text;

namespace SectorBuilder.Build.Content
{
    public interface ISourceFileContentProvider
    {
        string[] GetSourceFileLines();
    }
}
