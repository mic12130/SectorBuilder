using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectorBuilder.Index
{
    public class IndexData
    {
        public Dictionary<SectorSection, string[]> SourceFileCollection { get; }

        public IndexData(Dictionary<SectorSection, string[]> collection)
        {
            SourceFileCollection = collection;
        }
    }
}
