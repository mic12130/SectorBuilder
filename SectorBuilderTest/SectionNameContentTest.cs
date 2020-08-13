using NUnit.Framework;
using SectorBuilder.Build.Content;
using System;

namespace SectorBuilderTest
{
    public class SectionNameContentTest
    {
        [Test]
        public void GetLines()
        {
            var content = new SectionNameContent("SECTION");

            Assert.AreEqual(new string[] { "[SECTION]" }, content.GetLines());
        }

        [Test]
        public void ThrowsForEmptySectionName()
        {
            Assert.Throws<ArgumentException>(() => new SectionNameContent(""));
        }
    }
}
