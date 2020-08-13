using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectorBuilder.Build.Content
{
    public class SectionContentFactory
    {
        public static ISectorContent[] Create(string sectionName, string[] sourceFiles, bool sourceFileInfo)
        {
            var result = new List<ISectorContent>
            {
                new SectionNameContent(sectionName)
            };

            result.AddRange(CreateWithoutSectionName(sourceFiles, sourceFileInfo));

            return result.ToArray();
        }

        public static ISectorContent[] CreateWithoutSectionName(string[] sourceFiles, bool sourceFileInfo)
        {
            var result = new List<ISectorContent>();

            foreach (var file in sourceFiles)
            {
                if (sourceFileInfo)
                {
                    result.Add(new SourceFileInfoContent(file));
                }

                result.Add(new SourceFileContent(new SourceFileContentProvider(file)));
            }

            return result.ToArray();
        }
    }
}
