using System;
using System.Collections.Generic;
using System.Text;

namespace SectorBuilder.Build.Content
{
    public class SectionNameContent : ISectorContent
    {
        private readonly string _sectionName;

        public SectionNameContent(string sectionName)
        {
            if (sectionName.Length == 0)
            {
                throw new ArgumentException("Section name cannot be null");
            }

            _sectionName = sectionName;
        }

        public string[] GetLines()
        {
            return new string[] { $"[{_sectionName}]" };
        }
    }
}
