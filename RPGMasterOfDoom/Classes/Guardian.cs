﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Guardian : Character
    {
        public Guardian(string _name) : base(_name, 50, 150, 50, 50, 150, 150, 3, CharacterType.None, DamageType.None, true, false) { }
    }
}