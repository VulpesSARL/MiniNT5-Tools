using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Fox.Common
{
    public class BrandingDNSDecoder
    {
        public static bool ValidData = false;
        public static string Manufacturer = "";
        public static string SupportPhone = "";
        public static string SupportURL = "";
        public static byte[] BitmapData;

        /// <param name="TXTResponse">List of TXT elements from minint-branding.my-vulpes-config.lu</param>
        public static void DecodeBranding(List<List<string>> TXTResponse)
        {
            if (TXTResponse == null)
            {
                ValidData = false;
                return;
            }

            string MININTBR = "";
            foreach (List<string> TXTR in TXTResponse)
            {
                if (TXTR == null)
                    continue;

                foreach (string TXT in TXTR)
                {
                    if (TXT.StartsWith("MININTBR=") == true)
                    {
                        MININTBR = TXT.Substring(9);
                        break;
                    }
                }
                if (MININTBR != "")
                    break;
            }

            if (string.IsNullOrWhiteSpace(MININTBR) == true)
            {
                ValidData = false;
                return;
            }

            if (MININTBR.Split(',').Length < 2)
            {
                ValidData = false;
                return;
            }

            int NumBlocks;
            if (int.TryParse(MININTBR.Split(',')[0], out NumBlocks) == false)
            {
                ValidData = false;
                return;
            }

            string CRC = MININTBR.Split(',')[1].Trim();
            if (string.IsNullOrWhiteSpace(CRC) == true)
            {
                ValidData = false;
                return;
            }

            List<string> UUEBlocks = new List<string>();

            for (int i = 0; i < NumBlocks; i++)
            {
                bool Found = false;
                foreach (List<string> TXTR in TXTResponse)
                {
                    foreach (string TXT in TXTR)
                    {
                        if (TXT.StartsWith("MININTBR" + i.ToString("X2") + "=") == true)
                        {
                            Found = true;
                            UUEBlocks.Add(TXT.Substring(11));
                            break;
                        }
                    }
                    if (Found == true)
                        break;
                }
                if (Found == false)
                {
                    ValidData = false;
                    return;
                }
            }

            string FullUUEBlock = string.Join("", UUEBlocks);

            Crc32 crc32 = new Crc32();
            byte[] crc = crc32.ComputeHash(Encoding.ASCII.GetBytes(FullUUEBlock));

            string CRCStr = "";
            foreach (byte c in crc)
                CRCStr += c.ToString("X2");

            if (CRCStr.ToLower() != CRC.ToLower())
            {
                ValidData = false;
                return;
            }

            if (FullUUEBlock.Split('|').Length < 4)
            {
                ValidData = false;
                return;
            }

            byte[] bitmap = Convert.FromBase64String(FullUUEBlock.Split('|')[0]);
            Manufacturer = Encoding.UTF8.GetString(Convert.FromBase64String(FullUUEBlock.Split('|')[1]));
            SupportPhone = Encoding.UTF8.GetString(Convert.FromBase64String(FullUUEBlock.Split('|')[2]));
            SupportURL = Encoding.UTF8.GetString(Convert.FromBase64String(FullUUEBlock.Split('|')[3]));

            //actually the Bitmap is PNG Data, Windows wants for the OEM Logo BITMAP Data
            //Convert it here

            try
            {
                Image bmp = Bitmap.FromStream(new MemoryStream(bitmap));
                MemoryStream realbitmap = new MemoryStream();
                bmp.Save(realbitmap, ImageFormat.Bmp);
                realbitmap.Seek(0, SeekOrigin.Begin);
                BitmapData = new byte[realbitmap.Length];
                realbitmap.Read(BitmapData, 0, BitmapData.Length);
            }
            catch
            {

            }

            ValidData = true;
        }
    }
}
