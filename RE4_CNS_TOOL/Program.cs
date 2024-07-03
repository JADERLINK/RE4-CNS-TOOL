using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RE4_CNS_TOOL
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            Console.WriteLine("# RE4 CNS TOOL");
            Console.WriteLine("# By JADERLINK");
            Console.WriteLine("# VERSION 1.0.0 (2024-07-03)");
            Console.WriteLine("# youtube.com/@JADERLINK");
            Console.WriteLine("# CNS values - Research by AnonymousUser, Zatarita, Mr.Curious, and Mariokart64n");

            if (args.Length == 0)
            {
                Console.WriteLine("For more information read:");
                Console.WriteLine("https://github.com/JADERLINK/RE4-CNS-TOOL");
                Console.WriteLine("Press any key to close the console.");
                Console.ReadKey();
            }
            else if (args.Length >= 1 && File.Exists(args[0]))
            {
                string file = args[0];
                FileInfo info = null;

                try
                {
                    info = new FileInfo(file);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in the path: " + Environment.NewLine + ex);
                }
                if (info != null)
                {
                    Console.WriteLine("File: " + info.Name);
                    if (info.Exists)
                    {
                        if (info.Extension.ToUpperInvariant() == ".CNS")
                        {
                            try
                            {
                                Extract.ExtractFile(file);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + Environment.NewLine + ex);
                            }

                        }
                        else if (info.Extension.ToUpperInvariant() == ".IDXCNS")
                        {
                            try
                            {
                                Repack.RepackFile(file);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + Environment.NewLine + ex);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The extension is not valid: " + info.Extension);
                        }

                    }
                    else
                    {
                        Console.WriteLine("File specified does not exist.");
                    }

                }

            }
            else
            {
                Console.WriteLine("File specified does not exist.");
            }

            Console.WriteLine("Finished!!!");

        }
    }
}
