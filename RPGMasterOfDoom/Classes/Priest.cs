using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Priest : Character
    {
        public Priest(string _name) : base(_name, 75, 125, 50, 50, 150, 150, 1, CharacterType.None, DamageType.None, true, true) { }
    }
}
