using System;
using System.Collections.Generic;

namespace RPGMasterOfDoom
{
    class Program
    {
        static void Main(string[] args)
        {
            ICharacter wilmer = new Berserker("Wilmer");
            ICharacter juciande = new Ghoul("Juciande");
            ICharacter kalyani = new Guardian("Kalyani");
            ICharacter gerd = new Kamikaze("Gerd");
            ICharacter appius = new Lich("Appius");
            ICharacter anduin = new Priest("Anduin");
            ICharacter hector = new Robot("Hector");
            ICharacter simon = new Vampire("Simon");
            ICharacter grommash = new Warrior("Grommash");
            ICharacter phil = new Zombie("Phil");

            List<ICharacter> teamOneMembers = new List<ICharacter>();
            teamOneMembers.Add(wilmer);
            List<ICharacter> teamTwoMembers = new List<ICharacter>();
            teamTwoMembers.Add(juciande);
            List<ICharacter> teamThreeMembers = new List<ICharacter>();
            teamThreeMembers.Add(kalyani);
            List<ICharacter> teamFourMembers = new List<ICharacter>();
            teamFourMembers.Add(gerd);            
            List<ICharacter> teamFiveMembers = new List<ICharacter>();
            teamFiveMembers.Add(appius);            
            List<ICharacter> teamSixMembers = new List<ICharacter>();
            teamSixMembers.Add(anduin);            
            List<ICharacter> teamSevenMembers = new List<ICharacter>();
            teamSevenMembers.Add(hector);            
            List<ICharacter> teamEightMembers = new List<ICharacter>();
            teamEightMembers.Add(simon);
            List<ICharacter> teamNineMembers = new List<ICharacter>();
            teamNineMembers.Add(grommash);
            List<ICharacter> teamTenMembers = new List<ICharacter>();
            teamTenMembers.Add(phil);

            ICharacterTeam teamOne = new CharacterTeam(teamOneMembers, ConsoleColor.Red);
            ICharacterTeam teamTwo = new CharacterTeam(teamTwoMembers, ConsoleColor.Yellow);
            ICharacterTeam teamThree = new CharacterTeam(teamThreeMembers, ConsoleColor.DarkBlue);
            ICharacterTeam teamFour = new CharacterTeam(teamFourMembers, ConsoleColor.Cyan);
            ICharacterTeam teamFive = new CharacterTeam(teamFiveMembers, ConsoleColor.Magenta);
            ICharacterTeam teamSix = new CharacterTeam(teamSixMembers, ConsoleColor.Gray);
            ICharacterTeam teamSeven = new CharacterTeam(teamSevenMembers, ConsoleColor.Blue);
            ICharacterTeam teamEight = new CharacterTeam(teamEightMembers, ConsoleColor.Green);
            ICharacterTeam teamNine = new CharacterTeam(teamNineMembers, ConsoleColor.DarkRed);
            ICharacterTeam teamTen = new CharacterTeam(teamTenMembers, ConsoleColor.DarkGreen);

            List<ICharacterTeam> teams = new List<ICharacterTeam>();
            teams.Add(teamOne);
            teams.Add(teamTwo);
            teams.Add(teamThree);
            teams.Add(teamFour);
            teams.Add(teamFive);
            teams.Add(teamSix);
            teams.Add(teamSeven);
            teams.Add(teamEight);
            teams.Add(teamNine);
            teams.Add(teamTen);

            Arena.LaunchCombat(teams);
        }
    }
}
