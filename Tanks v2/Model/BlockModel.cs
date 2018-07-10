using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Model
{
    public class BlockModel : Interfaces.IBlockModel
    {
        List<Block> blocks = new List<Block>();
        int blockSize;

        public void CreateField(IEnumerable<string> field, int size)
        {
            blockSize = size;

            for (int i = 0; i<field.Count(); i++)
            {
                var line = field.ToArray<string>()[i];

                for (int j = 0; j<line.Length; j++)
                {
                    var blockName = line[j];
                    int x = blockSize * j;
                    int y = blockSize * i;

                    switch (blockName)
                    {
                        case 'b':
                            

                            blocks.Add(new Block("b", x, y, blockSize));

                            break;

                        case 'w':
                            blocks.Add(new Block("w", x, y, blockSize));

                            break;

                        case ' ':
                            break;

                        default:
                            throw new Exception("Undefined block name");
                    }
                }
            }
        }

        public IEnumerable<Block> GetBlocks() => blocks;
    }
}