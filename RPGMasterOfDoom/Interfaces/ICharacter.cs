using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    interface ICharacter
    {
        /// <summary>
        /// Deal damage to another character. The damage dealt depends on the current damage of the character.
        /// </summary>
        /// <param name="character">Character to deal damage to</param>
        /// <param name="bonusDamage">Bonus damage to deal. 0 by default</param>
        void DealDamage(ICharacter character, int bonusDamage = 0);

        /// <summary>
        /// Deal damage to the character.
        /// </summary>
        /// <param name="damage">Damage to deal</param>
        void TakeDamage(int damage, DamageType damageType);

        /// <summary>
        /// Launch the counter-attack to another character.
        /// </summary>
        /// <param name="character">Character to launch counter-attack on</param>
        /// <param name="bonusDamage">Bonus damage to deal</param>
        void Counter(ICharacter character, int bonusDamage);

        /// <summary>
        /// Update the number of rounds of pain.
        /// </summary>
        void DecrementRemainingRoundsOfPain();

        /// <summary>
        /// Reset the number of the current attack.
        /// </summary>
        void ResetCurrentAttackNumber();

        /// <summary>
        /// Returns the name.
        /// </summary>
        /// <returns></returns>
        string Name();

        /// <summary>
        /// Returns the current life.
        /// </summary>
        /// <returns></returns>
        int CurrentLife();

        /// <summary>
        /// Returns the current attack.
        /// </summary>
        /// <returns></returns>
        int CurrentAttack();

        /// <summary>
        /// Returns the current initiative.
        /// </summary>
        /// <returns></returns>
        int CurrentInitiative();

        /// <summary>
        /// Returns the current damage.
        /// </summary>
        /// <returns></returns>
        int CurrentDamage();

        /// <summary>
        /// Returns current defence.
        /// </summary>
        /// <returns></returns>
        int CurrentDefence();

        /// <summary>
        /// Inform if character is alive.
        /// </summary>
        /// <returns></returns>
        bool IsAlive();

        /// <summary>
        /// Inform if character can attack.
        /// </summary>
        /// <returns></returns>
        bool CanAttack();
    }
}
