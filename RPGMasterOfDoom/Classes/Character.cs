using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMasterOfDoom
{
    abstract class Character : ICharacter
    {
        protected string name { get; }
        protected CharacterType type { get; }
        protected int attack { get; set; }
        protected DamageType damageType { get; }
        protected int damage { get; set; }
        protected int defence { get; }
        protected int initiative { get; }
        protected int currentLife { get; set; }
        protected int maximumLife { get; }
        protected int remainingRoundsOfPain { get; set; } = 0;
        protected int remainingAttacksOnRound { get; set; }
        protected int maximumAttacksPerRound { get; set; }
        protected bool isAnAlive { get; }
        protected bool isAScavenger { get; }

        public Character(
            string _name,
            int _attack,
            int _defence,
            int _initiative,
            int _damage,
            int _maximumLife,
            int _currentLife,
            int _maximumAttacksPerRound,
            CharacterType _type,
            DamageType _damageType,
            bool _isAnAlive,
            bool _isAScavenger)
        {
            name = _name;
            attack = _attack;
            defence = _defence;
            initiative = _initiative;
            damage = _damage;
            maximumLife = _maximumLife;
            currentLife = _currentLife;
            maximumAttacksPerRound = _maximumAttacksPerRound;
            remainingAttacksOnRound = _maximumAttacksPerRound;
            type = _type;
            damageType = _damageType;
            isAnAlive = _isAnAlive;
            isAScavenger = _isAScavenger;
        }

        public void DealDamage(ICharacter character, int bonusDamage = 0)
        {
            if (currentLife <= 0 || remainingAttacksOnRound <= 0)
            {
                return;
            }

            BeforeDealDamage();

            int damageThrow = CalculateAttackThrow() + bonusDamage;
            int defenceThrow = character.CalculateDefenceThrow();
            int attackGap = damageThrow - defenceThrow;

            Console.WriteLine($"{name} tente d'attaquer {character.Name()}");

            if(attackGap > 0)
            {
                int damageToDeal = attackGap * damage / 100;
                Console.WriteLine($"{name} réussi son attaque et inflige {damageToDeal} dégats à {character.Name()}");
                character.TakeDamage(damageToDeal, damageType);
                remainingAttacksOnRound--;

                AfterDealDamage();
            }
            else
            {
                Console.WriteLine($"{name} a raté son attaque");
                character.Counter(this, attackGap * -1);
            }
        }

        public void TakeDamage(int damage, DamageType damageType)
        {
            if (isDamageCritical(damageType))
            {
                Console.WriteLine("Les dégats infligés sont critiques!");
                damage = damage * 2;
            }

            Console.WriteLine($"{name} subi {damage} dégats");

            int lifeBeforeTakingDamage = currentLife;

            currentLife -= damage;

            AfterTakingDamage(lifeBeforeTakingDamage, damage, currentLife);
        }

        private bool isDamageCritical(DamageType damageType)
        {
            try
            {
                return Constants.criticalDamageMap[damageType].Contains(type);
            } 
            catch
            {
                return false;
            }
        }

        public void Counter(ICharacter character, int counterBonusDamage)
        {
            int adjustedCounterBonusDamage = CalculateAdjustedCounterBonusDamage(counterBonusDamage);

            Console.WriteLine($"{name} contre-attaque avec {adjustedCounterBonusDamage} dégats bonus");
            DealDamage(character, adjustedCounterBonusDamage);
        }

        public void DecrementRemainingRoundsOfPain()
        {
            if (remainingRoundsOfPain > 0)
            {
                remainingRoundsOfPain--;
                Console.WriteLine($"Il reste {remainingRoundsOfPain} rounds de souffrance à {name}");
            }
        }

        public void ResetCurrentAttackNumber()
        {
            remainingAttacksOnRound = maximumAttacksPerRound;
        }

        public string Name()
        {
            return name;
        }

        public int CurrentLife()
        {
            return currentLife;
        }

        public int CurrentAttack()
        {
            return attack;
        }

        public int CurrentInitiative()
        {
            return initiative;
        }

        public int CurrentDamage()
        {
            return damage;
        }

        public int CurrentDefence()
        {
            return defence;
        }

        public bool IsAlive()
        {
            return currentLife > 0;
        }

        public bool CanAttack()
        {
            return IsAlive() && CurrentAttack() > 0;
        }

        public virtual int CalculateAttackThrow()
        {
            return Randomizer.Throw(damage);
        }

        public virtual int CalculateDefenceThrow()
        {
            return Randomizer.Throw(defence);
        }

        public virtual int CalculateRoundsOfPain()
        {
            return Randomizer.RoundsOfPain();
        }

        public virtual int CalculateAdjustedCounterBonusDamage(int counterBonusDamage)
        {
            return counterBonusDamage;
        }

        protected virtual void AfterTakingDamage(int lifeBeforeTakingDamage, int damage, int lifeAfterTakingDamage)
        {
            if (lifeAfterTakingDamage <= 0)
            {
                Console.WriteLine($"{name} est mort");
            }

            if (lifeAfterTakingDamage > 0 && damage > lifeAfterTakingDamage)
            {
                bool isSuffering = (damage - lifeAfterTakingDamage) * 2 / (lifeAfterTakingDamage + damage) > Randomizer.GetRandom().NextDouble();

                if (isSuffering)
                {
                    remainingRoundsOfPain += CalculateRoundsOfPain();
                    Console.WriteLine($"{name} souffre et a {remainingRoundsOfPain} rounds de souffrance");
                }
            }
        }

        public virtual void AtRoundBeginning() { }

        protected virtual void BeforeDealDamage() { }

        protected virtual void AfterDealDamage() { }
    }
}
