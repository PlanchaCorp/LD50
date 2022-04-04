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
        private GameEventPublisher unavailableActionEvent;
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
            if (spikeSpell != null)
            {
                EquippedSpell = spikeSpell;
                equipSpellEvent.Raise(new GameEvent(SPIKE));
            }
        }
        public void EquipSplashSpell()
        {
            SplashSpellType splashSpell = spellBook.EquippedSplashSpell;
            if (splashSpell != null)
            {
                EquippedSpell = splashSpell;
                equipSpellEvent.Raise(new GameEvent(SPLASH));

            }
        }
        public void EquipRaySpell()
        {
            RaySpellType raySpell = spellBook.EquippedRaySpell;
            if (raySpell != null)
            {
                EquippedSpell = raySpell;
                equipSpellEvent.Raise(new GameEvent(RAY));                
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
                GameObject spellCasted = Instantiate(spellPrefab, transform.position, transform.rotation);
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                spellCasted.GetComponent<SpikeSpell>().Cast((SpikeSpellType)EquippedSpell, mousePosition);
                spikeCooldown = EquippedSpell.Cooldown;
                castSpellEvent.Raise(new GameEvent(EquippedSpell));

            } else if (EquippedSpell.GetType() == typeof(RaySpellType))
            {
                if (rayCooldown > 0)
                {
                    return;
                }
                GameObject spellPrefab = EquippedSpell.Prefab;
                GameObject spellCasted = Instantiate(spellPrefab, transform.position, transform.rotation);
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                spellCasted.GetComponent<RaySpell>().Cast((RaySpellType)EquippedSpell, mousePosition);
                rayCooldown = EquippedSpell.Cooldown;
                castSpellEvent.Raise(new GameEvent(EquippedSpell));
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
            }
        }

        public void onPreSpellUpgrade(GameEvent gameEvent){
            if(skillPoint.Value>0){
                var spell =(SpellNumbers) gameEvent.Get();
                switch(spell){
                    case AURA:
                        spellBook.UpgradeAura();
                        return;
                    case SPIKE:
                        spellBook.UpgradeSpike();
                        return;
                    case RAY:
                        spellBook.UpgradeRay();
                        return;
                    case SPLASH :
                        spellBook.UpgradeSplash();
                        return;
                }
            }
            unavailableActionEvent.Raise(new GameEvent(this));
        }
    }
}
