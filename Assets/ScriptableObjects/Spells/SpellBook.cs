using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Spell Book")]
    public class SpellBook : ScriptableObject
    {
        [SerializeField]
        public List<GameObject> spells;

        public AuraSpellType EquippedAuraSpell;
        public SpikeSpellType EquippedSpikeSpell;
        public SplashSpellType EquippedSplashSpell;
        public RaySpellType EquippedRaySpell;

        [SerializeField]
        private int DefaultAuraSpellLevel;
        [SerializeField]
        private int DefaultSpikeSpellLevel;
        [SerializeField]
        private int DefaultSplashSpellLevel;
        [SerializeField]
        private int DefaultRaySpellLevel;
        
        [SerializeField]
        private SpellType AuraSpellType;
        [SerializeField]
        private SpellType SpikeSpellType;
        [SerializeField]
        private SpellType SplashSpellType;
        [SerializeField]
        private SpellType RaySpellType;

        public void OnEnable() {
            EquippedAuraSpell = null;
            EquippedSpikeSpell = null;
            EquippedSplashSpell = null;
            EquippedRaySpell = null;
            if (DefaultAuraSpellLevel > 0 && DefaultAuraSpellLevel <= AuraSpellType.spellVersions.Length) {
                EquippedAuraSpell = (AuraSpellType)AuraSpellType.spellVersions[DefaultAuraSpellLevel - 1];
            }
            if (DefaultSpikeSpellLevel > 0 && DefaultSpikeSpellLevel <= SpikeSpellType.spellVersions.Length)
            {
                EquippedSpikeSpell = (SpikeSpellType)SpikeSpellType.spellVersions[DefaultSpikeSpellLevel - 1];
            }
            if (DefaultSplashSpellLevel > 0 && DefaultSplashSpellLevel <= SplashSpellType.spellVersions.Length)
            {
                EquippedSplashSpell = (SplashSpellType)SplashSpellType.spellVersions[DefaultSplashSpellLevel - 1];
            }
            if (DefaultRaySpellLevel > 0 && DefaultRaySpellLevel <= RaySpellType.spellVersions.Length)
            {
                EquippedRaySpell = (RaySpellType)RaySpellType.spellVersions[DefaultRaySpellLevel - 1];
            }
        }
    }
}
