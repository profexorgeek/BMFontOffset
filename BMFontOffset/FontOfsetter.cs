using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace BMFontOffset
{
    public class FontOfsetter
    {
        public string SourceFontPath { get; set; }
        public string DestinationFontPath { get; set; }
        public int XOffset { get; set; }
        public int YOffset { get; set; }


        public FontOfsetter(string sourcePath, string destPath, int xOffset, int yOffset)
        {
            SourceFontPath = sourcePath;
            DestinationFontPath = destPath;
            XOffset = xOffset;
            YOffset = yOffset;
        }

        public FontOfsetter()
        {
            // intentionally empty constructor
        }

        public void ProcessFontFile()
        {
            if (string.IsNullOrEmpty(SourceFontPath) || !File.Exists(SourceFontPath))
            {
                throw new Exception("Bad source font file path provided: " + SourceFontPath);
            }

            var fnt = File.ReadAllText(SourceFontPath);

            // apply the x offsets
            fnt = Regex.Replace(fnt, "x=([0-9]+)", delegate (Match match)
            {
                var xVal = Convert.ToInt16(match.Groups[1].Value);
                var newX = xVal + XOffset;
                return "x=" + newX.ToString();
            });

            // apply the y offsets
            fnt = Regex.Replace(fnt, "y=([0-9]+)", delegate (Match match)
            {
                var yVal = Convert.ToInt16(match.Groups[1].Value);
                var newY = yVal + YOffset;
                return "y=" + newY.ToString();
            });

            if (string.IsNullOrWhiteSpace(DestinationFontPath))
            {
                throw new Exception("Bad or empty destination font file path provided.");
            }

            // write the file
            File.WriteAllText(DestinationFontPath, fnt);
        }


    }
}
