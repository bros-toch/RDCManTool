using CommandLine;

namespace RDCManTool.Console
{
    public class Options
    {
        [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
        public bool Verbose { get; set; }

        [Option("in", Required = true, HelpText = "Input file full path.")]
        public string Input { get; set; }

        [Option("out", Required = true, HelpText = "Output file full path.")]
        public string Output { get; set; }

        [Option('i', "import", Required = false, HelpText = "Import from another machine.")]
        public bool Import { get; set; }

        [Option('e', "export", Required = false, HelpText = "Export to another machine.")]
        public bool Export { get; set; }

        [Option('k', "key", Required = true, HelpText = "Key use for encrypting and decrypting.")]
        public string Key { get; set; }
    }
}