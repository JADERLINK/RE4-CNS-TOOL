using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RE4_CNS_TOOL_LITTLE_ENDIAN
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("# RE4 CNS TOOL (LITTLE ENDIAN)");
            Console.WriteLine("# By JADERLINK");
            Console.WriteLine("# VERSION 1.1.0 (2024-12-27)");
            Console.WriteLine("# youtube.com/@JADERLINK");
            Console.WriteLine("# github.com/JADERLINK");
            Console.WriteLine("# CNS values - Research by AnonymousUser, Zatarita, Mr.Curious, and Mariokart64n");

            RE4_CNS_TOOL.MainAction.Continue(args, SimpleEndianBinaryIO.Endianness.LittleEndian);
        }
    }
}
