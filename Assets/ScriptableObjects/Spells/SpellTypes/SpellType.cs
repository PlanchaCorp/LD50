using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Spell Type")]
    public class SpellType : ScriptableObject
    {
        [SerializeField]
        public AbstractSpellType[] spellVersions;

        public bool CanUpgrade(int currentLevel)
        {
            return currentLevel < spellVersions.Length - 1;
        }

        public AbstractSpellType GetNextLevel(int currentLevel) {
            try {
                return spellVersions[currentLevel];
            } catch (UnityException error) {
                Debug.LogError("Next spell level index out of bounds: you shouldn't call OnNextLevel without verifying OnCanUpgrade first");
                throw error;
            }
        }
    }
}
