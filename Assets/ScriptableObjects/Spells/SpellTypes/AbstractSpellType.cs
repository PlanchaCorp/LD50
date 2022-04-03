using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    public abstract class AbstractSpellType : ScriptableObject
    {
        [SerializeField]
        public GameObject Prefab;
        [SerializeField]
        private float Range;
        [SerializeField]
        private float HealAmount;
        [SerializeField]
        private float MaxDuration;
        [SerializeField]
        private float Cooldown;

        [SerializeField]
        public int Level;
        [SerializeField]
        public int minLevel;
    }
}
