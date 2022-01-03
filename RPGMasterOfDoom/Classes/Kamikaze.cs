using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Kamikaze : Character
    {
        public Kamikaze(string _name) : base(_name, 50, 125, 20, 75, 500, 500, 6, CharacterType.None, DamageType.None, true, false) { }
    }
}
