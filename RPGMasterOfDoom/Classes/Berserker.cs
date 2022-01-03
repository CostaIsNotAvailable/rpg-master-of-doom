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

        protected override void BeforeDealDamage()
        {
            int damageUp = maximumLife - currentLife;
            Console.WriteLine($"{name} ({this.GetType().Name}) augmente ces dégats de {damageUp} pour avoir un total de {damage += damageUp}");
            damage += damageUp;
        }

        protected override void AfterTakingDamage(int lifeBeforeTakingDamage, int damage, int lifeAfterTakingDamage)
        {
            int halfLife = maximumLife / 2;
            if (lifeBeforeTakingDamage > halfLife && lifeAfterTakingDamage < halfLife)
            {
                Console.WriteLine($"{name} ({this.GetType().Name}) a moins de la moitié de sa vie et peut donc attaquer 4 fois par tour");
                maximumAttacksPerRound = 4;
                remainingAttacksOnRound = 4;
            } 
        }
    }
}
