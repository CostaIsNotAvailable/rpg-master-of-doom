using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Zombie : Character
    {
        public Zombie(string _name) : base(_name, 100, 0, 20, 60, 1000, 1000, 1, CharacterType.None, DamageType.None, true, true) { }

        public override int CalculateDefenceThrow()
        {
            return 0;
        }
    }
}
