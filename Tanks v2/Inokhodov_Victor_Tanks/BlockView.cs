using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Inokhodov_Victor_Tanks
{
    public class BlocksView
    {
        public static void DrawBlocks(IEnumerable<Block> blocks, Graphics flagGraphics)
        {
            foreach (Block block in blocks)
            {
                if (block.IsEnabled)
                {
                    if (block.Name == "b")
                    {
                        flagGraphics.FillRectangle(Brushes.Gray, block.PosX, block.PosY, block.Size, block.Size);
                    }
                    else
                    {
                        flagGraphics.FillRectangle(Brushes.CornflowerBlue, block.PosX, block.PosY, block.Size, block.Size);
                    }
                }
            }

        }
    }
}