using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RE4_CNS_TOOL
{
    internal static class Extract
    {
        public static void ExtractFile(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
          
            var cns = new BinaryReader(fileInfo.OpenRead());
            uint Amount = cns.ReadUInt32();
            uint flags = cns.ReadUInt32();

            uint[] values = new uint[12];

            for (int i = 0; i < Amount && i < 12; i++)
            {
                values[i] = cns.ReadUInt32();
            }
            cns.Close();

            string idxFileName = fileInfo.FullName.Substring(0, fileInfo.FullName.Length - fileInfo.Extension.Length) + ".idxcns";

            StreamWriter idx = null;

            try
            {
                idx = new FileInfo(idxFileName).CreateText();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + Environment.NewLine + ex);
            }

            if (idx != null)
            {

                idx.WriteLine("# github.com/JADERLINK/RE4-CNS-TOOL");
                idx.WriteLine("# youtube.com/@JADERLINK");
                idx.WriteLine("# RE4 CNS TOOL By JADERLINK");
                idx.WriteLine("# CNS values - Research by AnonymousUser, Zatarita, Mr.Curious, and Mariokart64n");

                idx.WriteLine();
                idx.WriteLine("# [Flags]");
                idx.WriteLine("ENEMY_FLAG:" + ((flags & 0x001) == 0x001 ? 1 : 0));
                idx.WriteLine("OBJ_FLAG:" + ((flags & 0x002) == 0x002 ? 1 : 0));
                idx.WriteLine("ESP_FLAG:" + ((flags & 0x004) == 0x004 ? 1 : 0));
                idx.WriteLine("ESPGEN_FLAG:" + ((flags & 0x008) == 0x008 ? 1 : 0));
                idx.WriteLine("CTRL_FLAG:" + ((flags & 0x010) == 0x010 ? 1 : 0));
                idx.WriteLine("LIGHT_FLAG:" + ((flags & 0x020) == 0x020 ? 1 : 0));
                idx.WriteLine("PARTS_FLAG:" + ((flags & 0x040) == 0x040 ? 1 : 0));
                idx.WriteLine("MODEL_INFO_FLAG:" + ((flags & 0x080) == 0x080 ? 1 : 0));
                idx.WriteLine("PRIM_FLAG:" + ((flags & 0x100) == 0x100 ? 1 : 0));
                idx.WriteLine("EVT_FLAG:" + ((flags & 0x200) == 0x200 ? 1 : 0));
                idx.WriteLine("SAT_FLAG:" + ((flags & 0x400) == 0x400 ? 1 : 0));
                idx.WriteLine("EAT_FLAG:" + ((flags & 0x800) == 0x800 ? 1 : 0));

                idx.WriteLine();
                idx.WriteLine("# [Values]");
                idx.WriteLine("ENEMY_NUM:" + values[0].ToString());
                idx.WriteLine("OBJ_NUM:" + values[1].ToString());
                idx.WriteLine("ESP_NUM:" + values[2].ToString());
                idx.WriteLine("ESPGEN_NUM:" + values[3].ToString());
                idx.WriteLine("CTRL_NUM:" + values[4].ToString());
                idx.WriteLine("LIGHT_NUM:" + values[5].ToString());
                idx.WriteLine("PARTS_NUM:" + values[6].ToString());
                idx.WriteLine("MODEL_INFO_NUM:" + values[7].ToString());
                idx.WriteLine("PRIM_NUM:" + values[8].ToString());
                idx.WriteLine("EVT_NUM:" + values[9].ToString());
                idx.WriteLine("SAT_NUM:" + values[10].ToString());
                idx.WriteLine("EAT_NUM:" + values[11].ToString());
                idx.Close();
            }
        }
    }
}
