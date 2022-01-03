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

        public override List<ICharacter> AttackableCharacters(List<ICharacterTeam> remainingTeams)
        {
            return remainingTeams
                .SelectMany(team => team.Members())
                .Where(character => character.IsAlive())
                .ToList();
        }

        public override List<ICharacter> CharactersToAttack(List<ICharacter> attackableCharacters)
        {
            List<ICharacter> charactersToAttack = new List<ICharacter>();
            foreach (ICharacter character in attackableCharacters)
            {
                if (Randomizer.GetRandom().Next(0, 2) == 1)
                {
                    charactersToAttack.Add(character);
                }
            }
            return charactersToAttack;
        }
    }
}
