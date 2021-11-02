using System;
using System.Collections.Generic;

namespace RPGMasterOfDoom
{
    class Program
    {
        static void Main(string[] args)
        {
            ICharacter hector = new Character("Hector", 75, 75, 75, 30, 200, 200, 2, 1, CharacterType.Holy, DamageType.Blessed, true, false);
            ICharacter simon = new Character("Simon", 75, 75, 75, 30, 200, 185, 2, 2, CharacterType.Holy, DamageType.Blessed, true, false);
            ICharacter phil = new Character("Phil", 75, 75, 75, 30, 200, 200, 2, 1, CharacterType.Holy, DamageType.Blessed, true, false);

            List<ICharacter> teamOneMembers = new List<ICharacter>();
            teamOneMembers.Add(hector);
            List<ICharacter> teamTwoMembers = new List<ICharacter>();
            teamTwoMembers.Add(simon);
            List<ICharacter> teamThreeMembers = new List<ICharacter>();
            teamThreeMembers.Add(phil);

            ICharacterTeam teamOne = new CharacterTeam(teamOneMembers, ConsoleColor.Red);
            ICharacterTeam teamTwo = new CharacterTeam(teamTwoMembers, ConsoleColor.Yellow);
            ICharacterTeam teamThree = new CharacterTeam(teamThreeMembers, ConsoleColor.Green);

            List<ICharacterTeam> teams = new List<ICharacterTeam>();
            teams.Add(teamOne);
            teams.Add(teamTwo);
            teams.Add(teamThree);

            Arena.LaunchCombat(teams);
        }
    }
}
