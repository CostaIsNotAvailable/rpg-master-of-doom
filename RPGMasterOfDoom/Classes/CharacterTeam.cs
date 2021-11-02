using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    class CharacterTeam : ICharacterTeam
    {
        private List<ICharacter> members { get; } = new List<ICharacter>();

        private ConsoleColor color { get; }

        public CharacterTeam(List<ICharacter> _members, ConsoleColor _color)
        {
            members = _members;
            color = _color;
        }
        public List<ICharacter> Members()
        {
            return members;
        }
        public bool IsAlive()
        {
            return members.Any(m => m.IsAlive());
        }

        public bool CanAttack()
        {
            return members.Any(m => m.CanAttack());
        }

        public ConsoleColor Color()
        {
            return color;
        }
    }
}
