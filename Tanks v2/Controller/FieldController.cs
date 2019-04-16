using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class FieldController
    {
        private Model.Interfaces.IFieldModel fieldModel;

        public FieldController(int size, int enemies, int apples, int speed)
        {
            fieldModel = new FieldModel();
            fieldModel.Initialize(size, enemies, apples, speed);
        }

        public Entities.Field GetField() => fieldModel.GetField();
    }
}
