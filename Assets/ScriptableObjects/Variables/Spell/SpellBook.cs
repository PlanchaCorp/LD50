using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spell book")]
    public class SpellBook : ScriptableObject
    {
        [SerializeField]
        public List<GameObject> spells;
    }
}
