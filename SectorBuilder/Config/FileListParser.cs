using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SectorBuilder.Config
{
    public class FileListParser
    {
        static public FileListData ParseFromFile(string path)
        {
            return ParseFromString(File.ReadAllText(path));
        }

        static public FileListData ParseFromString(string source)
        {
            FileListData list;

            try
            {
                list = JsonConvert.DeserializeObject<FileListData>(source);
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                throw new JsonParserException(e.Message, e.Path, e.LineNumber, e.LinePosition, e.InnerException);
            }

            return list;
        }
    }
}
