using NUnit.Framework;
using SectorBuilder.Build.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SectorBuilderTest
{
    public class SectionContentFactoryTest
    {
        [Test]
        public void Create()
        {
            var contents = SectionContentFactory.Create("SECTION", new string[] { "1.txt", "2.txt" }, true);

            Assert.AreEqual(5, contents.Count());
            Assert.IsInstanceOf<SectionNameContent>(contents[0]);
            Assert.IsInstanceOf<SourceFileInfoContent>(contents[1]);
            Assert.IsInstanceOf<SourceFileContent>(contents[2]);
            Assert.IsInstanceOf<SourceFileInfoContent>(contents[3]);
            Assert.IsInstanceOf<SourceFileContent>(contents[4]);
        }

        [Test]
        public void CreateWithoutSectionName()
        {
            var contents = SectionContentFactory.CreateWithoutSectionName(new string[] { "1.txt", "2.txt" }, true);

            Assert.AreEqual(4, contents.Count());
            Assert.IsInstanceOf<SourceFileInfoContent>(contents[0]);
            Assert.IsInstanceOf<SourceFileContent>(contents[1]);
            Assert.IsInstanceOf<SourceFileInfoContent>(contents[2]);
            Assert.IsInstanceOf<SourceFileContent>(contents[3]);
        }

        [Test]
        public void CreateWithoutSourceFileInfo()
        {
            var contents = SectionContentFactory.Create("SECTION", new string[] { "1.txt", "2.txt" }, false);

            Assert.AreEqual(3, contents.Count());
            Assert.IsInstanceOf<SectionNameContent>(contents[0]);
            Assert.IsInstanceOf<SourceFileContent>(contents[1]);
            Assert.IsInstanceOf<SourceFileContent>(contents[2]);
        }

        [Test]
        public void CreateWithZeroSourceFile()
        {
            var contents = SectionContentFactory.Create("SECTION", new string[] { }, true);

            Assert.AreEqual(1, contents.Count());
            Assert.IsInstanceOf<SectionNameContent>(contents[0]);
        }
    }
}
