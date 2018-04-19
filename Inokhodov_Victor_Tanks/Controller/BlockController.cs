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
        public Model.Interfaces.IBlockModel BlockModel;

        public void InitializeField(IEnumerable<string> field, int blockSize)
        {
            BlockModel = new BlockModel();

            BlockModel.CreateField(field, blockSize);
        }
    }
}
