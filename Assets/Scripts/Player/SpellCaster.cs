using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;
using PlanchaCorp.LD50.Scripts.Spells;
using UnityEngine.InputSystem;
using static PlanchaCorp.LD50.Scripts.Spells.SpellNumbers;


namespace PlanchaCorp.LD50.Scripts.Player
{
    public class SpellCaster : MonoBehaviour
    {
        [SerializeField]
        private SpellBook spellBook;
        [SerializeField]
        private GameEventPublisher castSpellEvent;
        [SerializeField]
        private GameEventPublisher equipSpellEvent;
        [SerializeField]
        private IntVariable skillPoint;
        private AbstractSpellType EquippedSpell;
        private float spikeCooldown = 0;
        private float rayCooldown = 0;
        private float splashCooldown = 0;

        private void Start() {
            CastAuraSpell();
        }

        private void FixedUpdate() {
            spikeCooldown = Mathf.Max(0, spikeCooldown -= Time.fixedDeltaTime);
            rayCooldown = Mathf.Max(0, rayCooldown -= Time.fixedDeltaTime);
            splashCooldown = Mathf.Max(0, splashCooldown -= Time.fixedDeltaTime);
        }

        public void EquipSpikeSpell()
        {
            SpikeSpellType spikeSpell = spellBook.EquippedSpikeSpell;
            if (spikeSpell != null && spikeCooldown == 0)
            {
                EquippedSpell = spikeSpell;
            }
        }
        public void EquipSplashSpell()
        {
            SplashSpellType splashSpell = spellBook.EquippedSplashSpell;
            if (splashSpell != null && splashCooldown == 0)
            {
                EquippedSpell = splashSpell;
            }
        }
        public void EquipRaySpell()
        {
            RaySpellType raySpell = spellBook.EquippedRaySpell;
            if (raySpell != null && rayCooldown == 0)
            {
                EquippedSpell = raySpell;           
            }
        }

        public void CastAuraSpell()
        {
            AuraSpellType auraSpell = spellBook.EquippedAuraSpell;
            if (auraSpell != null) {
                GameObject spellPrefab = auraSpell.Prefab;
                GameObject spellCasted = Instantiate(spellPrefab, this.transform);
                spellCasted.GetComponent<AuraSpell>().Cast(auraSpell);
            }
        }
        public void CastSpell()
        {
            if (EquippedSpell == null) {
                return;
            }
            if (EquippedSpell.GetType() == typeof(SpikeSpellType)) {
                if (spikeCooldown > 0) {
                    return;
                }
                GameObject spellPrefab = EquippedSpell.Prefab;
                GameObject spellCasted = Instantiate(spellPrefab, this.transform);
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                spellCasted.GetComponent<SpikeSpell>().Cast((SpikeSpellType)EquippedSpell, mousePosition);
                spikeCooldown = EquippedSpell.Cooldown;
                castSpellEvent.Raise(new GameEvent(EquippedSpell));
                EquippedSpell =null;

            } else if (EquippedSpell.GetType() == typeof(RaySpellType))
            {
                if (rayCooldown > 0)
                {
                    return;
                }
                GameObject spellPrefab = EquippedSpell.Prefab;
                GameObject spellCasted = Instantiate(spellPrefab, this.transform);
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                spellCasted.GetComponent<RaySpell>().Cast((RaySpellType)EquippedSpell, mousePosition);
                rayCooldown = EquippedSpell.Cooldown;
                castSpellEvent.Raise(new GameEvent(EquippedSpell));
                EquippedSpell =null;
            }
            else if (EquippedSpell.GetType() == typeof(SplashSpellType))
            {
                if (splashCooldown > 0)
                {
                    return;
                }
                GameObject spellPrefab = EquippedSpell.Prefab;
                GameObject spellCasted = Instantiate(spellPrefab, transform.position, transform.rotation);
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                spellCasted.GetComponent<SplashSpellThrow>().Cast((SplashSpellType)EquippedSpell, mousePosition);
                splashCooldown = EquippedSpell.Cooldown;
                castSpellEvent.Raise(new GameEvent(EquippedSpell));
                EquippedSpell =null;
            }
        }

        public void onPreSpellUpgrade(GameEvent gameEvent){
            if(skillPoint.Value>0){
                var spell =(SpellNumbers) gameEvent.Get();
                switch(spell){
                    case AURA:
                        spellBook.UpgradeAura();
                        break;
                    case SPIKE:
                        spellBook.UpgradeSpike();
                        break;
                    case RAY:
                        spellBook.UpgradeRay();
                        break;
                    case SPLASH :
                        spellBook.UpgradeSplash();
                        break;    
                }
            }
        }
        public void onSpellSelection(GameEvent gameEvent){
            var spell =(SpellNumbers) gameEvent.Get();
                switch(spell){
                    case SPIKE:
                        EquipSpikeSpell();
                        break;
                    case RAY:
                        EquipRaySpell();
                        break;
                    case SPLASH :
                        EquipSplashSpell();
                        break;    
                }
        }
        public void onSpellCast(GameEvent gameEvent){
            var spell =(SpellNumbers) gameEvent.Get();
                switch(spell){
                    case SPIKE:
                        CastSpell();
                        break;
                    case RAY:
                        EquipRaySpell();
                        break;
                    case SPLASH :
                        EquipSplashSpell();
                        break;    
                }
        }
    }
}
