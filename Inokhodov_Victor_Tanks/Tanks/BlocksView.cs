using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Tanks
{
    public class BlocksView
    {
        public static void DrawBlocks(IEnumerable<Block> blocks, Graphics flagGraphics)
        {
            foreach (Block block in blocks)
            {
                var points = new Point[]
                {
                    new Point(block.PosX, block.PosY),
                    new Point(block.PosX + block.Size, block.PosY),
                    new Point(block.PosX, block.PosY + block.Size),
                };

                if (block.Name == "b")
                {
                    flagGraphics.FillRectangle(Brushes.Gray, block.PosX, block.PosY, block.Size, block.Size);
                }
                else
                {
                    flagGraphics.FillRectangle(Brushes.Gold, block.PosX, block.PosY, block.Size, block.Size);
                }
            }

        }
    }
}