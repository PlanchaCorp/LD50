using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class SplashSpellThrow : GenericSpell
    {
        [SerializeField]
        private SplashSpellExplosion explosionPrefab;
        private Vector2 direction;
        private float throwSpeed;
        private float maxDistance;
        private float currentDistance;

        public void Start() {
            currentDistance = 0;
        }
        public void Update() {
            Vector2 translation = direction * throwSpeed * Time.deltaTime;
            transform.Translate(translation);
            currentDistance += translation.magnitude;
            if (currentDistance > maxDistance) {
                GameObject splashSpellExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent).gameObject;
                splashSpellExplosion.GetComponent<SplashSpellExplosion>().Cast(spell);
                Destroy(gameObject);
            }
        }

        public void Cast(SplashSpellType splashSpell, Vector2 castPosition)
        {
            base.Cast(splashSpell);
            throwSpeed = splashSpell.ThrowSpeed;
            maxDistance = splashSpell.Range;
            direction = (castPosition - (Vector2)transform.position).normalized;
        }
    }
}
