using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SectorBuilder.Build.Content;
using SectorBuilder.Index;
using Serilog;

namespace SectorBuilder.Build
{
    public class SectorFileBuilder
    {
        private const string LineBreak = "\r\n";

        public static void Build(IndexData index, string sctPath, string esePath, bool sourceFileInfo)
        {
            BuildFile(index, sctPath, sourceFileInfo, new SectorSection[]
            {
                SectorSection.Color,
                SectorSection.Info,
                SectorSection.Airport,
                SectorSection.Runway,
                SectorSection.VOR,
                SectorSection.NDB,
                SectorSection.Fix,
                SectorSection.HighAirway,
                SectorSection.LowAirway,
                SectorSection.SID,
                SectorSection.STAR,
                SectorSection.ARTCC,
                SectorSection.ARTCCHigh,
                SectorSection.ARTCCLow,
                SectorSection.Label,
                SectorSection.Geo,
                SectorSection.Region
            });
            BuildFile(index, esePath, sourceFileInfo, new SectorSection[]
            {
                SectorSection.Position,
                SectorSection.Freetext,
                SectorSection.SIDSTAR,
                SectorSection.Airspace,
                SectorSection.Radar,
                SectorSection.Ground
            });
        }

        private static void BuildFile(IndexData index, string path, bool sourceFileInfo, SectorSection[] sections)
        {
            int fileLines = 0;
            using StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);
            Log.Debug($"Created writer for sector file at location \"{path}\".");

            foreach (var section in sections)
            {
                Log.Debug($"Now writing section \"{section}\".");

                string sectionName = SectorSectionNameMap.Map[section];
                ISectorContent[] sectionContents;
                int sectionLines = 0;

                if (sectionName == null)
                {
                    sectionContents = SectionContentFactory.CreateWithoutSectionName(
                        index.SourceFileCollection[section],
                        sourceFileInfo);
                }
                else
                {
                    sectionContents = SectionContentFactory.Create(
                        sectionName,
                        index.SourceFileCollection[section],
                        sourceFileInfo);
                }

                foreach (var content in sectionContents)
                {
                    var lines = content.GetLines();
                    foreach (var line in lines)
                    {
                        writer.Write(line + LineBreak);
                        fileLines += 1;
                        sectionLines += 1;
                    }
                    Log.Debug($"Wrote a sector content of type <{content.GetType().Name}>. ({lines.Count()} lines)");
                }
            }

            Log.Debug($"Complete writing sector file \"{path}\". Total lines: {fileLines}.");
        }
    }
}
