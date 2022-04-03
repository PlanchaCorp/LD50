using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Ray Spell")]
    public class RaySpellType : AbstractSpellType
    {
        [SerializeField]
        public float Width;
    }
}
