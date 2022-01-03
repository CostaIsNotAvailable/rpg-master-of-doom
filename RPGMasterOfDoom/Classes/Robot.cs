using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Robot : Character
    {
        public Robot(string _name) : base(_name, 10, 100, 50, 50, 200, 200, 1, CharacterType.None, DamageType.None, true, true) { }

        public override void AtRoundBeginning()
        {
            attack += Convert.ToInt32(Math.Ceiling(attack*0.5));
        }

        public override int CalculateAttackThrow()
        {
            return attack + 50;
        }

        public override int CalculateDefenceThrow()
        {
            return defence + 50;
        }
    }
}
