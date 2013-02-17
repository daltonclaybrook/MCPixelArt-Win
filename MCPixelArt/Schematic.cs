using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace MCPixelArt
{
    class Schematic
    {
        enum Tag {
            TAG_End,
            TAG_Byte,
            TAG_Short,
            TAG_Int,
            TAG_Long,
            TAG_Float,
            TAG_Double,
            TAG_Byte_Array,
            TAG_String,
            TAG_List,
            TAG_Compound,
            TAG_Int_Array
        };

        public byte[] CreateSchematic(int[] wool, Size size, bool subAir)
        {
            List<byte> bytes = new List<byte>();
            bool littleEndian = BitConverter.IsLittleEndian;
            String elementName;
            byte[] length;

            //Main Compound
            bytes.Add((byte)Tag.TAG_Compound);
            elementName = "Schematic";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));

            //Height
            bytes.Add((byte)Tag.TAG_Short);
            elementName = "Height";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            byte[] height = BitConverter.GetBytes((Int16)size.Height);
            if (littleEndian) Array.Reverse(height);
            bytes.AddRange(height);

            //Length
            bytes.Add((byte)Tag.TAG_Short);
            elementName = "Length";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            byte[] muralLength = BitConverter.GetBytes((Int16)1);
            if (littleEndian) Array.Reverse(muralLength);
            bytes.AddRange(muralLength);

            //Width
            bytes.Add((byte)Tag.TAG_Short);
            elementName = "Width";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            byte[] width = BitConverter.GetBytes((Int16)size.Width);
            if (littleEndian) Array.Reverse(width);
            bytes.AddRange(width);

            //Entities
            bytes.Add((byte)Tag.TAG_List);
            elementName = "Entities";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            bytes.Add((byte)Tag.TAG_Byte);
            byte[] listLength = BitConverter.GetBytes((Int32)0);
            if (littleEndian) Array.Reverse(listLength);
            bytes.AddRange(listLength);

            //TileEntities
            bytes.Add((byte)Tag.TAG_List);
            elementName = "TileEntities";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            bytes.Add((byte)Tag.TAG_Byte);
            bytes.AddRange(listLength);

            //Materials
            bytes.Add((byte)Tag.TAG_String);
            elementName = "Materials";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            elementName = "Alpha";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));

            //Data
            bytes.Add((byte)Tag.TAG_Byte_Array);
            elementName = "Data";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            byte[] woolCount = BitConverter.GetBytes((Int32)wool.Length);
            if (littleEndian) Array.Reverse(woolCount);
            bytes.AddRange(woolCount);
            for (int i = 0; i < wool.Length; i++)
            {
                bytes.Add((byte)wool[i]);
            }

            //Blocks
            bytes.Add((byte)Tag.TAG_Byte_Array);
            elementName = "Blocks";
            length = BitConverter.GetBytes((Int16)elementName.Length);
            if (littleEndian) Array.Reverse(length);
            bytes.AddRange(length);
            bytes.AddRange(Encoding.UTF8.GetBytes(elementName));
            bytes.AddRange(woolCount);
            for (int i = 0; i < wool.Length; i++)
            {
                byte woolID = (byte)wool[i];
                byte blockID = 35;
                if ((subAir == true) && (woolID == 0))
                {
                    blockID = 0;
                }
                bytes.Add(blockID);
            }

            //End
            bytes.Add((byte)Tag.TAG_End);

            return Compress(bytes.ToArray());
        }

        private byte[] Compress(byte[] input)
        {
            byte[] output;
            using (MemoryStream ms = new MemoryStream())
            {
                using (GZipStream gs = new GZipStream(ms, CompressionMode.Compress))
                {
                    gs.Write(input, 0, input.Length);
                    gs.Close();
                    output = ms.ToArray();
                }
                ms.Close();
            }
            return output;
        } 
    }
}
