using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;
using PlanchaCorp.LD50.Scripts.Player;

namespace PlanchaCorp.LD50.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Spell Book")]
    public class SpellBook : ScriptableObject
    {
        [SerializeField]
        public List<GameObject> spells;
        [SerializeField]
        private IntVariable availableSkillPoints;

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
        private SpellTypeArray AuraSpellTypeArray;
        [SerializeField]
        private SpellTypeArray SpikeSpellTypeArray;
        [SerializeField]
        private SpellTypeArray SplashSpellTypeArray;
        [SerializeField]
        private SpellTypeArray RaySpellTypeArray;

        public void OnEnable() {
            EquippedAuraSpell = null;
            EquippedSpikeSpell = null;
            EquippedSplashSpell = null;
            EquippedRaySpell = null;
            if (DefaultAuraSpellLevel > 0 && DefaultAuraSpellLevel <= AuraSpellTypeArray.spellVersions.Length) {
                EquippedAuraSpell = (AuraSpellType)AuraSpellTypeArray.spellVersions[DefaultAuraSpellLevel - 1];
            }
            if (DefaultSpikeSpellLevel > 0 && DefaultSpikeSpellLevel <= SpikeSpellTypeArray.spellVersions.Length)
            {
                EquippedSpikeSpell = (SpikeSpellType)SpikeSpellTypeArray.spellVersions[DefaultSpikeSpellLevel - 1];
            }
            if (DefaultSplashSpellLevel > 0 && DefaultSplashSpellLevel <= SplashSpellTypeArray.spellVersions.Length)
            {
                EquippedSplashSpell = (SplashSpellType)SplashSpellTypeArray.spellVersions[DefaultSplashSpellLevel - 1];
            }
            if (DefaultRaySpellLevel > 0 && DefaultRaySpellLevel <= RaySpellTypeArray.spellVersions.Length)
            {
                EquippedRaySpell = (RaySpellType)RaySpellTypeArray.spellVersions[DefaultRaySpellLevel - 1];
            }
        }

        public bool AuraNextLevelExist()
        {
            return EquippedAuraSpell.Level < AuraSpellTypeArray.spellVersions.Length;
        }
        public bool SpikeNextLevelExist()
        {
            return EquippedSpikeSpell.Level < SpikeSpellTypeArray.spellVersions.Length;
        }
        public bool SplashNextLevelExist()
        {
            return EquippedSplashSpell.Level < SplashSpellTypeArray.spellVersions.Length;
        }
        public bool RayNextLevelExist()
        {
            return EquippedRaySpell.Level < RaySpellTypeArray.spellVersions.Length;
        }

        public void UpgradeAura()
        {
            if (AuraNextLevelExist() && availableSkillPoints.Value > 0) {
                EquippedAuraSpell = (AuraSpellType)AuraSpellTypeArray.spellVersions[EquippedAuraSpell.Level];
                availableSkillPoints.Value -= 1;
            } else {

            }
        }
        public void UpgradeSpike()
        {
            if (SpikeNextLevelExist() && availableSkillPoints.Value > 0)
            {
                EquippedSpikeSpell = (SpikeSpellType)SpikeSpellTypeArray.spellVersions[EquippedSpikeSpell.Level];
                availableSkillPoints.Value -= 1;
            }
            else
            {

            }
        }
        public void UpgradeSplash()
        {
            if (SplashNextLevelExist() && availableSkillPoints.Value > 0)
            {
                EquippedSplashSpell = (SplashSpellType)SplashSpellTypeArray.spellVersions[EquippedSplashSpell.Level];
                availableSkillPoints.Value -= 1;
            }
            else
            {

            }
        }
        public void UpgradeRay()
        {
            if (RayNextLevelExist() && availableSkillPoints.Value > 0)
            {
                EquippedRaySpell = (RaySpellType)RaySpellTypeArray.spellVersions[EquippedRaySpell.Level];
                availableSkillPoints.Value -= 1;
            }
            else
            {

            }
        }
    }
}
