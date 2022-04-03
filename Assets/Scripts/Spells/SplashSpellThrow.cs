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
        private Vector2 direction = Vector2.zero;
        private float throwSpeed;
        private float maxDistance;
        private float currentDistance = 0;

        public void Start() {
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
            currentDistance = 0;
            throwSpeed = splashSpell.ThrowSpeed;
            Vector2 distance = castPosition - (Vector2)transform.position;
            maxDistance = Mathf.Min(splashSpell.Range, distance.magnitude);
            direction = distance.normalized;
        }
    }
}
