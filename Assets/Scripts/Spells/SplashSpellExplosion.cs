using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class SplashSpellExplosion : GenericOverTimeSpell
    {
        private float currentTime;

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
