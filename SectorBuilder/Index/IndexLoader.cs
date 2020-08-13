using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SectorBuilder.Config;
using Serilog;

namespace SectorBuilder.Index
{
    public class IndexLoader
    {
        private readonly IFileMatcher _fileMatcher;

        public IndexLoader(IFileMatcher fileMatcher)
        {
            _fileMatcher = fileMatcher;
        }

        public IndexData Load(string dir, FileListData fileList)
        {
            var result = new Dictionary<SectorSection, string[]>
            {
                [SectorSection.Color] = MatchSourceFiles(dir, fileList.Color),
                [SectorSection.Info] = MatchSourceFiles(dir, fileList.Info),
                [SectorSection.Airport] = MatchSourceFiles(dir, fileList.Airport),
                [SectorSection.Runway] = MatchSourceFiles(dir, fileList.Runway),
                [SectorSection.VOR] = MatchSourceFiles(dir, fileList.VOR),
                [SectorSection.NDB] = MatchSourceFiles(dir, fileList.NDB),
                [SectorSection.Fix] = MatchSourceFiles(dir, fileList.Fix),
                [SectorSection.HighAirway] = MatchSourceFiles(dir, fileList.HighAirway),
                [SectorSection.LowAirway] = MatchSourceFiles(dir, fileList.LowAirway),
                [SectorSection.SID] = MatchSourceFiles(dir, fileList.SID),
                [SectorSection.STAR] = MatchSourceFiles(dir, fileList.STAR),
                [SectorSection.ARTCC] = MatchSourceFiles(dir, fileList.ARTCC),
                [SectorSection.ARTCCHigh] = MatchSourceFiles(dir, fileList.ARTCCHigh),
                [SectorSection.ARTCCLow] = MatchSourceFiles(dir, fileList.ARTCCLow),
                [SectorSection.Label] = MatchSourceFiles(dir, fileList.Label),
                [SectorSection.Geo] = MatchSourceFiles(dir, fileList.Geo),
                [SectorSection.Region] = MatchSourceFiles(dir, fileList.Region),
                [SectorSection.Position] = MatchSourceFiles(dir, fileList.Position),
                [SectorSection.Freetext] = MatchSourceFiles(dir, fileList.Freetext),
                [SectorSection.SIDSTAR] = MatchSourceFiles(dir, fileList.SIDSTAR),
                [SectorSection.Airspace] = MatchSourceFiles(dir, fileList.Airspace),
                [SectorSection.Radar] = MatchSourceFiles(dir, fileList.Radar),
                [SectorSection.Ground] = MatchSourceFiles(dir, fileList.Ground)
            };

            return new IndexData(result);
        }

        private string[] MatchSourceFiles(string dir, List<string> fileListPaths)
        {
            Log.Debug("Start matching file list paths for the next section.");

            if (fileListPaths == null || fileListPaths.Count == 0)
            {
                Log.Debug("No file list path is in this section.");
                return new string[] { };
            }

            List<string> sourceFiles = new List<string>();

            foreach (var fileListPath in fileListPaths)
            {
                sourceFiles.AddRange(MatchSourceFilesFromSinglePath(dir, fileListPath));
            }

            Log.Debug($"Matched {sourceFiles.Count} source files from {fileListPaths.Count} file list paths for this section.");
            return sourceFiles.ToArray();
        }

        private string[] MatchSourceFilesFromSinglePath(string dir, string fileListPath)
        {
            List<string> files = _fileMatcher.MatchFiles(dir, fileListPath).ToList();
            files.Sort();

            Log.Debug($"Matched {files.Count} source files from file list path \"{fileListPath}\": [{string.Join(", ", files)}].");
            return files.ToArray();
        }
    }
}
