using NUnit.Framework;
using Moq;
using SectorBuilder.Config;
using SectorBuilder.Index;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Linq;

namespace SectorBuilderTest
{
    public class IndexLoaderTest
    {
        private Mock<IFileMatcher> _fileMatcher;

        [SetUp]
        public void SetUp()
        {
            _fileMatcher = new Mock<IFileMatcher>();
        }

        [Test]
        public void Load()
        {
            var fileMatcher = new MockFileMatcher();
            fileMatcher.Wish("dir", "*.txt", new string[] { "dir/1.txt", "dir/3.txt", "dir/2.txt" });

            var indexLoader = new IndexLoader(fileMatcher);
            var fileList = new FileListData { Geo = new List<string> { "*.txt" } };

            var indexData = indexLoader.Load("dir", fileList);

            // We also verified the sorting behaviour here
            Assert.AreEqual(new string[] { "dir/1.txt", "dir/2.txt", "dir/3.txt" },
                indexData.SourceFileCollection[SectorSection.Geo]);
        }

        [Test]
        public void LoadWithNullInput()
        {
            var indexLoader = new IndexLoader(_fileMatcher.Object);
            var fileList = new FileListData { Geo = null };

            var indexData = indexLoader.Load("whatever", fileList);

            Assert.AreEqual(new List<string> { }, indexData.SourceFileCollection[SectorSection.Geo]);
        }

        [Test]
        public void LoadWithEmptyInput()
        {
            var indexLoader = new IndexLoader(_fileMatcher.Object);
            var fileList = new FileListData { Geo = new List<string> { } };

            var indexData = indexLoader.Load("whatever", fileList);

            Assert.AreEqual(new List<string> { }, indexData.SourceFileCollection[SectorSection.Geo]);
        }
    }
}
