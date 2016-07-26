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
            byte[] typeArray = new byte[sizeX * sizeY * sizeZ];
            byte[] metadataArray = new byte[sizeX * sizeY * sizeZ / 2];
            byte[] lightArray = new byte[sizeX * sizeY * sizeZ / 2];
            byte[] skyArray = new byte[sizeX * sizeY * sizeZ / 2];

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        int index = y + (z * sizeY) + (x * sizeY * sizeZ);
                        typeArray[index] = 0x01; //stone
                        if (index % 2 == 0)
                        {         
                            metadataArray[index/2] = 0x00;
                            lightArray[index/2] = 0x00;
                            skyArray[index/2] = 0x00;
                        }
                    }
                }
            }          
                

            using (MemoryStream compressedStream = new MemoryStream())
            {
                using (DeflateStream compressionStream = new DeflateStream(compressedStream, CompressionMode.Compress))
                {
                    compressionStream.Write(typeArray, 0, typeArray.Length);
                    compressionStream.Write(metadataArray, 0, metadataArray.Length);
                    compressionStream.Write(lightArray, 0, lightArray.Length);
                    compressionStream.Write(skyArray, 0, skyArray.Length);
                }
                return compressedStream.ToArray();
            }
            
        }
    }

    
}
