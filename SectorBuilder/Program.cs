using System;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using CommandLine;

namespace SectorBuilder
{
    class SectorBuilderOptions
    {
        [Value(0, Required = true, HelpText = "Path to the file list.")]
        public string FileListPath { get; set; }

        [Option("output-name", Default = "a", HelpText = "The name of output sector files.")]
        public string OutputName { get; set; }

        [Option("output-dir", Default = "./.build", HelpText = "The directory where sector files will be built.")]
        public string OutputDir { get; set; }

        [Option("insert-sources", Default = false, HelpText = "Appends source file info to output sector files.")]
        public bool InsertSourceInfo { get; set; }

        [Option("verbose", Default = false, HelpText = "Increases logging verbosity for debugging purposes.")]
        public bool Verbose { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var options = Parser.Default.ParseArguments<SectorBuilderOptions>(args)
                .WithParsed(o =>
                {
                    var loggingLevel = new LoggingLevelSwitch { MinimumLevel = o.Verbose ? LogEventLevel.Debug : LogEventLevel.Information };
                    Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.ControlledBy(loggingLevel)
                    .WriteTo.Console()
                    .CreateLogger();

                    bool succeed = Run(o);
                    Log.CloseAndFlush();

                    if (!succeed)
                    {
                        Environment.Exit(1);
                    }
                })
                .WithNotParsed(e => { Environment.Exit(1); });
        }

        static bool Run(SectorBuilderOptions opts)
        {
            Log.Information("Build started.");

            if (TryGetFullPath(opts.FileListPath, out string fullFileListPath) == false)
            {
                Log.Error($"The file list path \"{opts.FileListPath}\" is invalid.");
                return false;
            }

            if (TryGetFullPath(opts.OutputDir, out string fullOutputDir) == false)
            {
                Log.Error($"The output directory path \"{opts.OutputDir}\" is invalid.");
                return false;
            }

            try
            {
                new BuildManager(fullFileListPath, opts.OutputName, fullOutputDir, opts.InsertSourceInfo).Build();
            }
            catch (ApplicationException e)
            {
                Log.Error($"An error occured: \"{e.Message}\". Sector Builder will exit.");
                return false;
            }
            catch (Exception e)
            {
                Log.Error(e, "An unhandled exception occured. Sector Builder will exit.");
                return false;
            }

            Log.Information("Build succeeded.");
            return true;
        }

        static bool TryGetFullPath(string path, out string result)
        {
            try
            {
                result = System.IO.Path.GetFullPath(path);
            }
            catch (Exception)
            {
                result = "";
                return false;
            }

            return true;
        }
    }
}
