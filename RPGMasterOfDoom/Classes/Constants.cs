using System.Collections.Generic;

namespace RPGMasterOfDoom
{
    static class Constants
    {
        public readonly static List<CharacterType> cursedCriticalDamages = new List<CharacterType>()
        {
            CharacterType.Holy
        };

        public readonly static List<CharacterType> blessedCriticalDamages = new List<CharacterType>()
        {
            CharacterType.Impious
        };

        public readonly static Dictionary<DamageType, List<CharacterType>> criticalDamageMap = new Dictionary<DamageType, List<CharacterType>>()
        {
            { DamageType.Cursed, cursedCriticalDamages },
            { DamageType.Blessed, blessedCriticalDamages }
        };
    }
}
