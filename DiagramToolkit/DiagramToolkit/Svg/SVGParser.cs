using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svg;

namespace DiagramToolkit.Svg
{
    public class SVGParser
    {
        static string newPath = @"E:\Ronald\Kuliah\Semester7\Konstruksi Perangkat Lunak\FPKPL\DiagramToolkit\DiagramToolkit\ImageSvg\";
        // static byte[] newPath = Resources.AssetSvg.wyre_dark01_info;
        // The maximum image size supported.
        public static Size MaximumSize { get; set; }

        // Converts an SVG file to a Bitmap image.
        public static Bitmap GetBitmapFromSVG(string filePath)
        {
            // SvgDocument document = GetSvgDocument(filePath);
            SvgDocument document = SvgDocument.Open(newPath + filePath);

            Bitmap bmp = document.Draw();
            return bmp;
        }

        // Gets a SvgDocument for manipulation using the path provided.
        public static SvgDocument GetSvgDocument(string filePath)
        {
            SvgDocument document = SvgDocument.Open(filePath);
            return AdjustSize(document);
        }

        // Makes sure that the image does not exceed the maximum size, while preserving aspect ratio.
        private static SvgDocument AdjustSize(SvgDocument document)
        {
            if (document.Height > MaximumSize.Height)
            {
                document.Width = (int)((document.Width / (double)document.Height) * MaximumSize.Height);
                document.Height = MaximumSize.Height;
            }
            return document;
        }
    }
}
