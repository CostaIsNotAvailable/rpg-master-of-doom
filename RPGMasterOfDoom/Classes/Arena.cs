using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    static class Arena
    {
        private static ConsoleColor consoleColor { get; } = ConsoleColor.White;
        public static void LaunchCombat(List<ICharacterTeam> teams)
        {
            Console.ForegroundColor = consoleColor;

            Console.WriteLine("------------------- Début de la partie -------------------");
            foreach (ICharacterTeam team in teams)
            {
                Console.ForegroundColor = team.Color();
                foreach (ICharacter character in team.Members())
                {
                    Console.WriteLine($"{character.Name()} a {character.CurrentLife()} points de vie");
                }
            }
            Console.ForegroundColor = consoleColor;

            List<ICharacterTeam> remainingTeams = GetRemainingTeams(teams);

            List<ICharacter> charactersThatWillAttack = GetCharactersThatCanAttack(remainingTeams);
            int round = 1;
            do
            {
                Console.WriteLine($"------------------- Round {round} -------------------");
                charactersThatWillAttack = charactersThatWillAttack.OrderByDescending(c => Randomizer.Throw(c.CurrentInitiative())).ToList();
                while (charactersThatWillAttack.Count > 0)
                {
                    ICharacter character = charactersThatWillAttack[0];

                    ICharacterTeam characterTeam = remainingTeams
                        .Where(team => team.Members()
                        .Contains(character))
                        .First();

                    Console.ForegroundColor = characterTeam.Color();

                    remainingTeams = GetRemainingTeams(teams);

                    List<ICharacterTeam> ennmyTeams = remainingTeams
                        .Where(team => !team.Members()
                        .Contains(character))
                        .ToList();

                    List<ICharacter> attackableCharacters = ennmyTeams
                        .SelectMany(team => team.Members())
                        .Where(character => character.IsAlive())
                        .ToList();

                    if (attackableCharacters.Any())
                    {
                        ICharacter characterToAttack = attackableCharacters[Randomizer.GetRandom().Next(attackableCharacters.Count)];

                        if (character.CanAttack() && characterToAttack.IsAlive())
                        {
                            character.DealDamage(characterToAttack);
                        }

                        if (!characterToAttack.IsAlive())
                        {
                            charactersThatWillAttack.Remove(characterToAttack);
                        }
                    }

                    charactersThatWillAttack.Remove(character);
                }

                DecrementRemainingRoundsOfPain(teams);
                ResetAttackNumbers(teams);

                Console.ForegroundColor = consoleColor;

                remainingTeams = GetRemainingTeams(teams);
                charactersThatWillAttack = GetCharactersThatCanAttack(remainingTeams);

                Console.WriteLine($"------------------- Fin du round {round} -------------------");
                foreach (ICharacterTeam team in teams)
                {
                    Console.ForegroundColor = team.Color();
                    foreach (ICharacter character in team.Members())
                    {
                        Console.WriteLine($"{character.Name()} a {character.CurrentLife()} points de vie");
                    }
                }
                Console.ForegroundColor = consoleColor;

                round++;
            } while (remainingTeams.Count >= 2 && charactersThatWillAttack.Any());
            Console.WriteLine("------------------- Fin de la partie -------------------");

            Console.WriteLine($"L'équipe {remainingTeams[0].Color()} a gagné");
        }

        private static List<ICharacterTeam> GetRemainingTeams(List<ICharacterTeam> teams)
        {
            return teams.Where(t => t.IsAlive()).ToList();
        }

        private static List<ICharacter> GetCharactersThatCanAttack(List<ICharacterTeam> teams)
        {
            List<ICharacter> charactersThatCanAttack = new List<ICharacter>();
            foreach (ICharacterTeam team in teams)
            {
                foreach (ICharacter character in team.Members())
                {
                    if (character.CanAttack())
                        charactersThatCanAttack.Add(character);
                }
            }
            return charactersThatCanAttack;
        }

        private static void DecrementRemainingRoundsOfPain(List<ICharacterTeam> teams)
        {
            foreach (ICharacterTeam team in teams)
            {
                foreach (ICharacter character in team.Members())
                {
                    character.DecrementRemainingRoundsOfPain();
                }
            }
        }

        private static void ResetAttackNumbers(List<ICharacterTeam> teams)
        {
            foreach (ICharacterTeam team in teams)
            {
                foreach (ICharacter character in team.Members())
                {
                    if (character.IsAlive())
                    {
                        character.ResetCurrentAttackNumber();
                    }
                }
            }
        }
    }
}
