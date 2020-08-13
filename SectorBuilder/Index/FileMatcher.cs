using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using GlobExpressions;

namespace SectorBuilder.Index
{
    public class FileMatcher : IFileMatcher
    {
        public string[] MatchFiles(string dir, string pattern)
        {
            if (Directory.Exists(dir) == false)
            {
                throw new DirectoryNotFoundException($"The base direcotry \"{dir}\" for file matching is not found.");
            }

            string[] files;

            try
            {
                files = Glob.Files(dir, pattern).Select(f => Path.Combine(dir, f)).ToArray();
            }
            catch (GlobPatternException e)
            {
                throw new FileMatcherException($"The pattern \"{pattern}\" is invalid.", dir, pattern, e.InnerException);
            }

            return files;
        }
    }
}
