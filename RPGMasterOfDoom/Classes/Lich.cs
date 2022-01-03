using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Lich : Character
    {
        public Lich(string _name) : base(_name, 75, 125, 80, 50, 125, 125, 3, CharacterType.Impious, DamageType.Cursed, true, true) { }
    }
}
