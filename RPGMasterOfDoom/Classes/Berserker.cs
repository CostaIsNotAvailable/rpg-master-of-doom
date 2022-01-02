using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Berserker : Character
    {
        public Berserker(string _name) : base(_name, 100, 100, 80, 20, 300, 300, 1, CharacterType.None, DamageType.None, true, false) { }
    }
}
