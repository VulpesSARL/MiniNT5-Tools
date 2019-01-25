using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fox.Common;

namespace FoxShellIcon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fox Shell Icon");
            Console.WriteLine("");
            if (args.Length < 3)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("");
                Console.WriteLine("delete ID TYPE");
                Console.WriteLine("  ID           \"ID\" of the icon");
                Console.WriteLine("  TYPE         \"USER\" or \"SYSTEM\"");
                Console.WriteLine("");
                Console.WriteLine("add ID TYPE NAME GROUP EXECUTABLE [ICONFILE] [ORDER] [USESHELLEX]");
                Console.WriteLine("  ID           \"ID\" of the icon");
                Console.WriteLine("  TYPE         \"USER\" or \"SYSTEM\"");
                Console.WriteLine("  NAME         Name of the icon");
                Console.WriteLine("  GROUP        Group of the icon");
                Console.WriteLine("  EXECUTABLE   Executable");
                Console.WriteLine("  ICONFILE     Different icon, if specified");
                Console.WriteLine("  ORDER        Custom ordering, numeric, if specified");
                Console.WriteLine("  USESHELLEX   Use ShellEx, TRUE or FALSE (default: FALSE)");
                return;
            }
            switch (args[0].ToLower())
            {
                case "delete":
                    {
                        IcoListData ico = new IcoListData();
                        ico.ID = args[1];
                        switch (args[2].ToLower())
                        {
                            case "user":
                                ico.Type = IcoListRegType.User;
                                break;
                            case "system":
                                ico.Type = IcoListRegType.System;
                                break;
                            default:
                                Console.WriteLine("Unknown type");
                                return;
                        }
                        IcoListNamedPipes.DeleteIcon(ico.ID, ico.Type);
                        break;
                    }
                case "add":
                    {
                        if (args.Length < 6)
                        {
                            Console.WriteLine("Not enough argurments");
                            break;
                        }
                        IcoListData ico = new IcoListData();
                        ico.ID = args[1];
                        switch (args[2].ToLower())
                        {
                            case "user":
                                ico.Type = IcoListRegType.User;
                                break;
                            case "system":
                                ico.Type = IcoListRegType.System;
                                break;
                            default:
                                Console.WriteLine("Unknown type");
                                return;
                        }
                        ico.Name = args[3];
                        ico.Group = args[4];
                        ico.Execute = args[5];
                        if (args.Length > 6)
                            ico.IcoFile = args[6];
                        else
                            ico.IcoFile = ico.Execute;
                        if (args.Length > 7)
                        {
                            if (int.TryParse(args[7], out ico.Order) == false)
                                ico.Order = 0;
                        }
                        else
                        {
                            ico.Order = 0;
                        }
                        if (args.Length > 8)
                        {
                            switch (args[8].ToLower())
                            {
                                case "true":
                                    ico.UseShellEx = true;
                                    break;
                                case "false":
                                    ico.UseShellEx = false;
                                    break;
                                default:
                                    Console.WriteLine("Unknown type");
                                    return;
                            }
                        }
                        else
                        {
                            ico.UseShellEx = false;
                        }

                        IcoListNamedPipes.AddIcon(ico.ID, ico.Name, ico.Group, ico.IcoFile, ico.Execute, ico.Order, ico.UseShellEx, ico.Type);
                        break;
                    }
                default:
                    Console.WriteLine("Unknown action");
                    return;
            }
        }
    }
}
