using Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BlockController
    {
        public Model.Interfaces.IBlockModel blockModel;

        public void InitializeField(IEnumerable<string> field, int blockSize)
        {
            blockModel = new BlockModel();

            blockModel.CreateField(field, blockSize);
        }

        public IEnumerable<Block> GetBlocks() => blockModel.GetBlocks();
    }
}