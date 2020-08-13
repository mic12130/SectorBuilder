using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using SectorBuilder.Index;
using SectorBuilder.Build;
using SectorBuilder.Config;
using Serilog;

namespace SectorBuilder
{
    public class BuildManager
    {
        private readonly string _fileListPath;
        private readonly string _outputName;
        private readonly string _outputDir;
        private readonly bool _insertSourceInfo;

        public BuildManager(string fileListPath, string outputName, string outputDir, bool insertSourceInfo)
        {
            _fileListPath = fileListPath;
            _outputName = outputName;
            _outputDir = outputDir;
            _insertSourceInfo = insertSourceInfo;
        }

        public void Build()
        {
            Log.Debug($"Building with parameters: " +
                $"File list path: {_fileListPath}, " +
                $"Output name: {_outputName}, " +
                $"Output directory: {_outputDir}, " +
                $"Insert source info: {_insertSourceInfo}.");

            PrepareOutputDir();
            var fileList = ParseFileList();
            var index = LoadIndex(fileList);
            BuildSectorFile(index);
        }

        private void PrepareOutputDir()
        {
            if (Directory.Exists(_outputDir) == false)
            {
                try
                {
                    Directory.CreateDirectory(_outputDir);
                    Log.Debug($"Output directory created.");
                }
                catch (IOException e)
                {
                    Log.Error($"An IO exception occured while creating the output directory \"{_outputDir}\". Message: \"{e.Message}\".");
                    throw new ApplicationException("Failed to create the output directory.");
                }
            }
        }

        private FileListData ParseFileList()
        {
            if (File.Exists(_fileListPath) == false)
            {
                Log.Error($"File list not found at location \"{_fileListPath}\".");
                throw new ApplicationException("File list not found.");
            }

            FileListData fileList;

            Log.Information("Parsing file list.");
            try
            {
                fileList = FileListParser.ParseFromFile(_fileListPath);
            }
            catch (IOException e)
            {
                Log.Error($"An IO exception occured while parsing file list at location \"{_fileListPath}\". Message: \"{e.Message}\".");
                throw new ApplicationException("Failed to parse file list.");
            }
            catch (JsonParserException e)
            {
                Log.Error($"Syntax error in file list \"{_fileListPath}\". " +
                    $"Message: \"{e.Message}\". Path: {e.Path}. Line: {e.LineNumber}. Line position: {e.LinePosition}.");
                throw new ApplicationException("Syntax error in file list.");
            }
            Log.Information("File list parsed.");

            return fileList;
        }

        private IndexData LoadIndex(FileListData fileList)
        {
            string baseDir = Path.GetDirectoryName(_fileListPath);
            Log.Debug($"Extracted the base directory \"{baseDir}\" for files matching.");

            IndexData index;

            Log.Information("Indexing.");
            try
            {
                index = new IndexLoader(new FileMatcher()).Load(baseDir, fileList);
            }
            catch (FileMatcherException e)
            {
                Log.Error($"The file list path \"{e.Pattern}\" is invalid for files matching. Message: \"{e.Message}\".");
                throw new ApplicationException("A file list path is invalid for files matching.");
            }
            catch (IOException e)
            {
                Log.Error($"An IO exception occured while loading index. Message: \"{e.Message}\".");
                throw new ApplicationException("Failed to load index.");
            }

            Log.Information($"Index loaded. Indexed files count: {index.SourceFileCollection.Values.SelectMany(v => v).Count()}.");
            return index;
        }

        private void BuildSectorFile(IndexData index)
        {
            Log.Information("Building sector files.");
            string sctPath = Path.Combine(_outputDir, $"{_outputName}.sct");
            string esePath = Path.Combine(_outputDir, $"{_outputName}.ese");

            try
            {
                SectorFileBuilder.Build(index, sctPath, esePath, _insertSourceInfo);
            }
            catch (IOException e)
            {
                Log.Error($"An IO exception occured while building sector files. Message: {e.Message}.");
                throw new ApplicationException("An IO exception occured while building sector files.");
            }
            Log.Information($"Complete building sector files at location \"{sctPath}\" and \"{esePath}\".");
        }
    }
}
