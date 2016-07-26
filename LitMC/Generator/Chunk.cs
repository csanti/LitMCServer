using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;


namespace LitMC.Generator
{
    public struct ChunkKey
    {
        int x, y;
    }

    public class Chunk
    {
        public static byte[] generateSimpleChunk(byte sizeX, byte sizeY, byte sizeZ) //real sizes
        {

            byte[] typeArray = new byte[sizeX * sizeY * sizeZ / 2];

            byte[] metadataArray = new byte[sizeX * sizeY * sizeZ / 2];
            byte[] lightArray = new byte[sizeX * sizeY * sizeZ / 2];
            byte[] skyArray = new byte[sizeX * sizeY * sizeZ / 2];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        int index = y + (z * (sizeY + 1)) + (x * (sizeY + 1) * (sizeZ + 1));
                        typeArray[index] = 0x01; //stone
                        if (index % 0 == 0)
                        {
                            metadataArray[index] = 0x00;
                            lightArray[index] = 0x00;
                            skyArray[index] = 0x00;
                        }
                    }
                }
            }

            using (MemoryStream uncompresssedStream = new MemoryStream())
            {
                uncompresssedStream.Write(typeArray, 0, typeArray.Length);
                uncompresssedStream.Write(metadataArray, typeArray.Length, metadataArray.Length);
                uncompresssedStream.Write(lightArray, typeArray.Length + metadataArray.Length, lightArray.Length);
                uncompresssedStream.Write(skyArray, typeArray.Length + metadataArray.Length + lightArray.Length, skyArray.Length);

                using (MemoryStream compressedStream = new MemoryStream())
                {
                    using (DeflateStream compressionStream = new DeflateStream(compressedStream, CompressionMode.Compress))
                    {
                        uncompresssedStream.CopyTo(compressionStream);
                    }
                    return compressedStream.ToArray();
                }
            }
        }
    }

    
}
