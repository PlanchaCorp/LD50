using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Spells/Splash Spell")]
    public class SplashSpellType : AbstractSpellType
    {
        [SerializeField]
        private float Radius;
        [SerializeField]
        public float Duration;
        [SerializeField]
        public float ThrowSpeed;
    }
}
