using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IBlockModel
    {
        void CreateField(IEnumerable<string> field, int blockSize);
        IEnumerable<Block> GetBlocks();
    }
}