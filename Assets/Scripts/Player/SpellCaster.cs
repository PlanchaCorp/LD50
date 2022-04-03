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

        private void Start() {
            CastAuraSpell();
        }

        private void FixedUpdate() {
            spikeCooldown = Mathf.Max(0, spikeCooldown -= Time.fixedDeltaTime);
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
        public void CastSpikeSpell()
        {
            SpikeSpellType spikeSpell = spellBook.EquippedSpikeSpell;
            if (spikeSpell != null && spikeCooldown == 0)
            {
                GameObject spellPrefab = spikeSpell.Prefab;
                GameObject spellCasted = Instantiate(spellPrefab, this.transform);
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                spellCasted.GetComponent<SpikeSpell>().Cast(spikeSpell, mousePosition);
                spikeCooldown = spikeSpell.Cooldown;
            }
        }
    }
}
