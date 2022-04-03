using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;
using PlanchaCorp.LD50.Scripts.Spells;

public class SpellCaster : MonoBehaviour
{
    [SerializeField]
    private SpellBook spellBook;

    public void CastAuraSpell(GameEvent spellEvent)
    {
        AuraSpellType auraSpell = spellBook.EquippedAuraSpell;
        if (auraSpell != null) {
            GameObject spellPrefab = auraSpell.Prefab;
            GameObject spellCasted = Instantiate(spellPrefab, this.transform);
            spellCasted.GetComponent<AuraSpell>().cast(0, 1, 1);
        }
    }
}
