//created my craig marshall
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;

namespace create_random_file
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: create-random-file.exe outfile sizeinMb");
                return;
            }

            string filePath = args[0];
            int sizeInMb = Int32.Parse(args[1]);
            // Note: block size must be a factor of 1MB to avoid rounding errors
            const int blockSize = 1024 * 8;
            const int blocksPerMb = (1024 * 1024) / blockSize;

            byte[] data = new byte[blockSize];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                using (FileStream stream = File.OpenWrite(filePath))
                {
                    for (int i = 0; i < sizeInMb * blocksPerMb; i++)
                    {
                        crypto.GetBytes(data);
                        stream.Write(data, 0, data.Length);
                    }
                }
            }
        }



    }
}
