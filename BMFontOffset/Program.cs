using System;

namespace BMFontOffset
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                string srcFile = Convert.ToString(args[0]);
                int xOffset = Convert.ToInt16(args[1]);
                int yOffset = Convert.ToInt16(args[2]);
                string destFile = Convert.ToString(args[3]);

                var offsetter = new FontOfsetter(srcFile, destFile, xOffset, yOffset);

                Console.WriteLine("Processing font file.");
                offsetter.ProcessFontFile();
                Console.WriteLine("Processing complete, file created at: " + destFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad arguments provided to application. Expected syntax: ");
                Console.WriteLine("BMFontOffset [source file path] [x offset] [y offset] [destination path]");
                Console.WriteLine(e.Message);
            }

        }
    }
}
