using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FieldModel : Interfaces.IFieldModel
    {
        private Field field;

        public void Initialize(int size, int enemies, int apples, int speed)
            => field = new Field(size, enemies, apples, speed);

        public Field GetField() => field;
    }
}
