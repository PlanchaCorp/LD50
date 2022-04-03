using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;
using PlanchaCorp.LD50.Scripts.Spells;
using UnityEngine.InputSystem;

namespace PlanchaCorp.LD50.Scripts.Player
{
    public class SpellCaster : MonoBehaviour
    {
        [SerializeField]
        private SpellBook spellBook;

        private AbstractSpellType EquippedSpell;

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
            }
        }
        public void EquipSplashSpell()
        {
            SplashSpellType spikeSpell = spellBook.EquippedSplashSpell;
            if (spikeSpell != null)
            {
                EquippedSpell = spikeSpell;
            }
        }
        public void EquipRaySpell()
        {
            RaySpellType spikeSpell = spellBook.EquippedRaySpell;
            if (spikeSpell != null)
            {
                EquippedSpell = spikeSpell;
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

        private float spikeCooldown = 0;
        private float rayCooldown = 0;
        private float splashCooldown = 0;
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
            }
        }
    }
}
