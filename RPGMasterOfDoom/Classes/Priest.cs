using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class Priest : Character
    {
        public Priest(string _name) : base(_name, 75, 125, 50, 50, 150, 150, 1, CharacterType.Holy, DamageType.Blessed, true, true) { }

        public override List<ICharacter> AttackableCharacters(List<ICharacterTeam> remainingTeams)
        {
            ICharacterTeam characterTeam = remainingTeams
                .Where(team => team.Members()
                .Contains(this))
                .First();

            List<ICharacterTeam> ennemyTeams = remainingTeams
                .Where(team => !team.Members()
                .Contains(this))
                .ToList();

            List<ICharacter> ennemyCharacters = ennemyTeams
                .SelectMany(team => team.Members())
                .Where(character => character.IsAlive())
                .ToList();

            if (ennemyCharacters.Any(c => !c.IsAlive()))
            {
                return ennemyCharacters
                    .Where(c => !c.IsAlive())
                    .ToList();
            } 
            else
            {
                return ennemyCharacters;
            }
        }

        public override void AtRoundBeginning()
        {
            currentLife = Math.Min(Convert.ToInt32(Math.Ceiling(currentLife + currentLife * 0.1)), maximumLife);
        }
    }
}
