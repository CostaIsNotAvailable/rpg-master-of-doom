using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Vampire : Character
    {
        public Vampire(string _name) : base(_name, 100, 100, 120, 50, 300, 300, 2, CharacterType.None, DamageType.None, false, false) { }

        protected override void AfterDealDamage(int damage)
        {
            currentLife = Math.Min(currentLife + damage, maximumLife);
        }
    }
}
