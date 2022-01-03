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

        public override void BeforeDealDamage()
        {
            damage += maximumLife - currentLife;
        }

        public override void AfterTakingDamage(int lifeBeforeTakingDamage, int damage, int lifeAfterTakingDamage)
        {
            int halfLife = maximumLife / 2;
            if (lifeBeforeTakingDamage > halfLife && lifeAfterTakingDamage < halfLife)
            {
                maximumAttacksPerRound = 4;
            } 
        }
    }
}
