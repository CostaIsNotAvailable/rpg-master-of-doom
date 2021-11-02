using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    interface ICharacterTeam : ITeam<ICharacter>
    {
        /// <summary>
        /// Inform if at least a member of the team still alive
        /// </summary>
        bool IsAlive();
        /// <summary>
        /// Inform if at least a member of the team can attack
        /// </summary>
        bool CanAttack();
        /// <summary>
        /// Returns the team color
        /// </summary>
        ConsoleColor Color();
    }
}
