using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface ICollisionable
    {
        int PosX { get; }
        int PosY { get; }
        int Size { get; }
    }
}
