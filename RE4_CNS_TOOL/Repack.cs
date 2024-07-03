using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace RE4_CNS_TOOL
{
    internal static class Repack
    {
        public static void RepackFile(string file)
        {
            StreamReader idx = null;
            FileInfo fileInfo = new FileInfo(file);
            string baseName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
            string baseDiretory = fileInfo.DirectoryName;

            try
            {
                idx = new FileInfo(file).OpenText();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + Environment.NewLine + ex);
            }

            if (idx != null)
            {
                uint flags = 0;
                uint[] values = new uint[12];

                string endLine = "";
                while (endLine != null)
                {
                    endLine = idx.ReadLine();

                    if (endLine != null)
                    {
                        endLine = endLine.Trim();

                        if (!(endLine.Length == 0
                            || endLine.StartsWith("#")
                            || endLine.StartsWith("\\")
                            || endLine.StartsWith("/")
                            || endLine.StartsWith(":")
                            || endLine.StartsWith("!")
                            ))
                        {
                            _ = SetUintDex(ref endLine, "ENEMY_NUM", ref values[0])
                                || SetUintDex(ref endLine, "OBJ_NUM", ref values[1])
                                || SetUintDex(ref endLine, "ESP_NUM", ref values[2])
                                || SetUintDex(ref endLine, "ESPGEN_NUM", ref values[3])
                                || SetUintDex(ref endLine, "CTRL_NUM", ref values[4])
                                || SetUintDex(ref endLine, "LIGHT_NUM", ref values[5])
                                || SetUintDex(ref endLine, "PARTS_NUM", ref values[6])
                                || SetUintDex(ref endLine, "MODEL_INFO_NUM", ref values[7])
                                || SetUintDex(ref endLine, "PRIM_NUM", ref values[8])
                                || SetUintDex(ref endLine, "EVT_NUM", ref values[9])
                                || SetUintDex(ref endLine, "SAT_NUM", ref values[10])
                                || SetUintDex(ref endLine, "EAT_NUM", ref values[11])
                                || SetFlag(ref endLine, "ENEMY_FLAG", ref flags, 0x01)
                                || SetFlag(ref endLine, "OBJ_FLAG", ref flags, 0x02)
                                || SetFlag(ref endLine, "ESP_FLAG", ref flags, 0x04)
                                || SetFlag(ref endLine, "ESPGEN_FLAG", ref flags, 0x08)
                                || SetFlag(ref endLine, "CTRL_FLAG", ref flags, 0x10)
                                || SetFlag(ref endLine, "LIGHT_FLAG", ref flags, 0x20)
                                || SetFlag(ref endLine, "PARTS_FLAG", ref flags, 0x40)
                                || SetFlag(ref endLine, "MODEL_INFO_FLAG", ref flags, 0x80)
                                || SetFlag(ref endLine, "PRIM_FLAG", ref flags, 0x0100)
                                || SetFlag(ref endLine, "EVT_FLAG", ref flags, 0x0200)
                                || SetFlag(ref endLine, "SAT_FLAG", ref flags, 0x0400)
                                || SetFlag(ref endLine, "EAT_FLAG", ref flags, 0x0800);
                        }

                    }

                }
                idx.Close();

                BinaryWriter cns = null;
                try
                {
                    cns = new BinaryWriter(new FileInfo(baseDiretory + "\\" + baseName + ".CNS").Create(), Encoding.GetEncoding(1252));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + Environment.NewLine + ex);
                }

                if (cns != null)
                {
                    uint amount = 0;
                    amount = ((flags & 0x001) == 0x001 ? 1 : amount);
                    amount = ((flags & 0x002) == 0x002 ? 2 : amount);
                    amount = ((flags & 0x004) == 0x004 ? 3 : amount);
                    amount = ((flags & 0x008) == 0x008 ? 4 : amount);
                    amount = ((flags & 0x010) == 0x010 ? 5 : amount);
                    amount = ((flags & 0x020) == 0x020 ? 6 : amount);
                    amount = ((flags & 0x040) == 0x040 ? 7 : amount);
                    amount = ((flags & 0x080) == 0x080 ? 8 : amount);
                    amount = ((flags & 0x100) == 0x100 ? 9 : amount);
                    amount = ((flags & 0x200) == 0x200 ? 10 : amount);
                    amount = ((flags & 0x400) == 0x400 ? 11 : amount);
                    amount = ((flags & 0x800) == 0x800 ? 12 : amount);

                    cns.Write(amount);
                    cns.Write(flags);
                    for (int i = 0; i < amount; i++)
                    {
                        cns.Write(values[i]);
                    }

                    // preenchimento
                    int length = (int)amount * 4 + 8;
                    int div = length / 32;
                    int rest = length % 32;
                    div += rest != 0 ? 1 : 0;
                    int final = div * 32;
                    int dif = final - length;
                    byte[] bdif = new byte[dif];
                    for (int i = 0; i < dif; i++)
                    {
                        bdif[i] = 0xCD;
                    }
                    cns.Write(bdif);
                    cns.Close();
                }
            }
        }


        private static bool SetUintDex(ref string line, string key, ref uint varToSet)
        {
            if (line.StartsWith(key))
            {
                var split = line.Split(':');
                if (split.Length >= 2)
                {
                    try
                    {
                        varToSet = uint.Parse(ReturnValidDecValue(split[1]), NumberStyles.Integer, CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                    }
                }
                return true;
            }
            return false;

        }

        private static bool SetFlag(ref string line, string key, ref uint Flag, uint mask)
        {
            if (line.StartsWith(key))
            {
                var split = line.Split(':');
                if (split.Length >= 2)
                {
                    try
                    {
                        uint val = uint.Parse(ReturnValidDecValue(split[1]), NumberStyles.Integer, CultureInfo.InvariantCulture);
                        if (val != 0)
                        {
                            Flag |= mask;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return true;
            }
            return false;

        }

        public static string ReturnValidDecValue(string cont)
        {
            string res = "";
            foreach (var c in cont)
            {
                if (char.IsDigit(c))
                {
                    res += c;
                }
            }
            return res;
        }
    }
}
