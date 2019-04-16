using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IFieldModel
    {
        void Initialize(int size, int enemies, int apples, int speed);
        Entities.Field GetField();
    }
}
