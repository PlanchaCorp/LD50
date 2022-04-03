using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class AuraSpell : GenericOverTimeSpell
    {
        public void Cast(AbstractSpellType auraSpell, Vector2 castPosition)
        {
            Debug.Log("Aura Spell");
            base.Cast(auraSpell);
        }
    }
}
