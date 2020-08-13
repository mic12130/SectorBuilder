using NUnit.Framework;
using Moq;
using SectorBuilder.Build.Content;
using System;
using System.Linq;

namespace SectorBuilderTest
{
    public class SourceFileContentTest
    {
        [Test]
        public void GetLines()
        {
            var provider = new Mock<ISourceFileContentProvider>();
            var content = new SourceFileContent(provider.Object);
            provider.Setup(p => p.GetSourceFileLines()).Returns(new string[] { "line-1", "line-2" });

            var lines = content.GetLines();

            Assert.AreEqual(2, lines.Count());
            Assert.AreEqual(new string[] { "line-1", "line-2" }, lines);
        }

        [Test]
        public void GetLinesWithEmptyFile()
        {
            var provider = new Mock<ISourceFileContentProvider>();
            var content = new SourceFileContent(provider.Object);
            provider.Setup(p => p.GetSourceFileLines()).Returns(new string[] { });

            Assert.AreEqual(new string[] { "; <Empty Source File>" }, content.GetLines());
        }
    }
}
