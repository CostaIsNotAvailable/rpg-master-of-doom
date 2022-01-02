using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Ghoul : Character
    {
        public Ghoul(string _name) : base(_name, 50, 80, 120, 30, 250, 250, 5, CharacterType.None, DamageType.None, true, true) { }
    }
}
