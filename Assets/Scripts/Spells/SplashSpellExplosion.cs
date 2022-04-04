using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class SplashSpellExplosion : GenericOverTimeSpell
    {
        [SerializeField]
        private AudioSource splashSound;
        private float currentTime;

        public new void Cast(AbstractSpellType splashSpell) {
            base.Cast(splashSpell);
            if (splashSound != null) {
                splashSound.Play();
            }
        }

        private void Start() {
            currentTime = 0;
        }

        private void Update()
        {
            currentTime += Time.deltaTime;
            if (currentTime > ((SplashSpellType)spell).Duration)
            {
                Destroy(gameObject);
            }
        }
    }
}
