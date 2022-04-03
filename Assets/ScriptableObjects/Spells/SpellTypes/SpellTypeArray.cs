using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Spell Type Array")]
    public class SpellTypeArray : ScriptableObject
    {
        [SerializeField]
        public AbstractSpellType[] spellVersions;
    }
}
