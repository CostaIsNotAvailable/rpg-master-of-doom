using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Warrior : Character
    {
        public Warrior(string _name) : base(_name, 100, 100, 50, 100, 200, 200, 2, CharacterType.None, DamageType.None, true, false) { }
    }
}
