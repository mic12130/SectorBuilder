using NUnit.Framework;
using Moq;
using SectorBuilder.Build.Content;
using System;
using System.Linq;

namespace SectorBuilderTest
{
    public class SourceFileInfoContentTest
    {
        [Test]
        public void GetLines()
        {
            var content = new SourceFileInfoContent("path");
            var lines = content.GetLines();

            Assert.AreEqual(3, lines.Count());
            Assert.IsTrue(lines[0].StartsWith("; -----"));
            Assert.IsTrue(lines[2].StartsWith("; -----"));
            Assert.AreEqual("; SOURCE: path", lines[1]);
        }

        [Test]
        public void ThrowsForEmptySourceFilePath()
        {
            Assert.Throws<ArgumentException>(() => new SourceFileInfoContent(""));
        }
    }
}
