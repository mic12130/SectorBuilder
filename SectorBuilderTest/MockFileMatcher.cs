using System;
using System.Collections.Generic;
using System.Text;
using SectorBuilder.Index;

namespace SectorBuilderTest
{
    public class MockFileMatcher : IFileMatcher
    {
        private Dictionary<Tuple<string, string>, string[]> returnFilesMap;

        public MockFileMatcher()
        {
            returnFilesMap = new Dictionary<Tuple<string, string>, string[]>();
        }

        public void Wish(string dir, string pattern, string[] files)
        {
            returnFilesMap.Add(Tuple.Create(dir, pattern), files);
        }

        public string[] MatchFiles(string dir, string pattern)
        {
            return returnFilesMap[Tuple.Create(dir, pattern)];
        }
    }
}
