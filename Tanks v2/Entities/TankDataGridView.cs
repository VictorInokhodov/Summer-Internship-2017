using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TankDataGridView
    {
        public int Id { get; set; } = 0;
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool IsDefeated { get; set; }

        public static TankDataGridView GetDataTank(Tank tank)
        {
            return new TankDataGridView()
            {
                Id = tank.Id,
                PosX = tank.PosX,
                PosY = tank.PosY,
                IsDefeated = !tank.IsEnable
            };
        }
    }
}
