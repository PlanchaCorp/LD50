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
        private GameEventPublisher postUpgradeEvent;

        private AuraSpellType equippedAura;
        public AuraSpellType EquippedAuraSpell{
            get{ return equippedAura;}
        }
        private SpikeSpellType equippedSpike;
        public SpikeSpellType EquippedSpikeSpell{
            get{return equippedSpike;}
        }
        private SplashSpellType equippedSplash;
        public SplashSpellType EquippedSplashSpell{
            get{return equippedSplash;}
        }
        private RaySpellType equippedRay;
        public RaySpellType EquippedRaySpell{
            get{return equippedRay;}
        }

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
            equippedAura = null;
            equippedSpike = null;
            equippedSplash = null;
            equippedRay = null;
            if (DefaultAuraSpellLevel > 0 && DefaultAuraSpellLevel <= AuraSpellTypeArray.spellVersions.Length) {
                equippedAura = (AuraSpellType)AuraSpellTypeArray.spellVersions[DefaultAuraSpellLevel - 1];
            }
            if (DefaultSpikeSpellLevel > 0 && DefaultSpikeSpellLevel <= SpikeSpellTypeArray.spellVersions.Length)
            {
                equippedSpike = (SpikeSpellType)SpikeSpellTypeArray.spellVersions[DefaultSpikeSpellLevel - 1];
            }
            if (DefaultSplashSpellLevel > 0 && DefaultSplashSpellLevel <= SplashSpellTypeArray.spellVersions.Length)
            {
                equippedSplash = (SplashSpellType)SplashSpellTypeArray.spellVersions[DefaultSplashSpellLevel - 1];
            }
            if (DefaultRaySpellLevel > 0 && DefaultRaySpellLevel <= RaySpellTypeArray.spellVersions.Length)
            {
                equippedRay = (RaySpellType)RaySpellTypeArray.spellVersions[DefaultRaySpellLevel - 1];
            }
        }

        public bool AuraNextLevelExist()
        {
            if(EquippedAuraSpell is null){
                return true;
            }
            return EquippedAuraSpell.Level < AuraSpellTypeArray.spellVersions.Length;
        }
        public bool SpikeNextLevelExist()
        {
            if(EquippedSpikeSpell is null){
                return true;
            }
            return EquippedSpikeSpell.Level < SpikeSpellTypeArray.spellVersions.Length;
        }
        public bool SplashNextLevelExist()
        {
            if(EquippedSplashSpell is null){
                return true;
            }
            return EquippedSplashSpell.Level < SplashSpellTypeArray.spellVersions.Length;
        }
        public bool RayNextLevelExist()
        {
            if(EquippedRaySpell is null){
                return true;
            }
            return EquippedRaySpell.Level < RaySpellTypeArray.spellVersions.Length;
        }

        public void UpgradeAura()
        {
            if (AuraNextLevelExist()) {
                equippedAura = (AuraSpellType)AuraSpellTypeArray.spellVersions[EquippedAuraSpell.Level];
                postUpgradeEvent.Raise(new GameEvent(EquippedAuraSpell));
            }
        }
        public void UpgradeSpike()
        {
            if (SpikeNextLevelExist())
            {
                if(EquippedSpikeSpell != null){
                equippedSpike = (SpikeSpellType)SpikeSpellTypeArray.spellVersions[equippedSpike.Level];
                } else {
                    equippedSpike = (SpikeSpellType)SpikeSpellTypeArray.spellVersions[0];
                }
                postUpgradeEvent.Raise(new GameEvent(EquippedSpikeSpell));
            }
        }
        public void UpgradeSplash()
        {
            if (SplashNextLevelExist())
            {
                if(EquippedSplashSpell != null){
                    equippedSplash = (SplashSpellType)SplashSpellTypeArray.spellVersions[equippedSplash.Level];
                } else {
                    equippedSplash= (SplashSpellType)SplashSpellTypeArray.spellVersions[0];
            }
                postUpgradeEvent.Raise(new GameEvent(EquippedSplashSpell));
            }
        }
        public void UpgradeRay()
        {
            if (RayNextLevelExist())
            {
                if(EquippedRaySpell != null){
                equippedRay = (RaySpellType)RaySpellTypeArray.spellVersions[EquippedRaySpell.Level];
                } else {
                equippedRay = (RaySpellType)RaySpellTypeArray.spellVersions[0];
                }
                postUpgradeEvent.Raise(new GameEvent(EquippedRaySpell));
        }
    }
}
}
