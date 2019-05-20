using System.IO;
using CommandLine;
namespace RDCManTool.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    if (!File.Exists(o.Input))
                    {
                        System.Console.WriteLine($"Input file {o.Input} doesn't exist.");
                        return;
                    }

                    if (!File.Exists(o.Input))
                    {
                        System.Console.WriteLine($"Output file {o.Output} doesn't exist.");
                        return;
                    }

                    if (!o.Import && !o.Export)
                    {
                        System.Console.WriteLine($"Please select either --import or --export.");
                        return;
                    }

                    if (o.Import)
                    {
                        RdcToolHelper.Import(o.Input, o.Output, o.Key);
                    }
                    else if(o.Export)
                    {
                        RdcToolHelper.Export(o.Input, o.Output, o.Key);
                    }

                    System.Console.WriteLine($"File is saved to: {o.Output}");
                });
        }
    }
}
