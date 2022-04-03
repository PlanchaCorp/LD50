using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Spike Spell")]
    public class SpikeSpellType : AbstractSpellType
    {
        [SerializeField]
        public float Angle;
    }
}
