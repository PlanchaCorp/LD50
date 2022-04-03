using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    public abstract class AbstractSpellType : ScriptableObject
    {
        [SerializeField]
        public int Level;

        [SerializeField]
        public GameObject Prefab;
        [SerializeField]
        public float Range;
        [SerializeField]
        public float HealAmount;
        [SerializeField]
        public float Cooldown;
    }
}
