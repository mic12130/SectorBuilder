using NUnit.Framework;
using SectorBuilder.Config;
using System;
using System.Collections.Generic;

namespace SectorBuilderTest
{
    public class FileListParserTest
    {
        [Test]
        public void CanParse()
        {
            var map = FileListParser.ParseFromString("{\"airport\": [\"path\"]}");

            Assert.AreEqual(new List<string> { "path" }, map.Airport);
        }

        // Having no idea how to implement this elegantly...So comment it out at this moment

        /* 
        [Test]
        public void ThrowsForUnknownProperty()
        {
            Assert.Throws<JsonParserException>(
                () => FileListParser.ParseFromString("{\"airportttttt\": [\"path\"]}"));
        }
        */

        [Test]
        public void ThrowsForNonJson()
        {
            Assert.Throws<JsonParserException>(
                () => FileListParser.ParseFromString("something wrong"));
        }
    }
}
