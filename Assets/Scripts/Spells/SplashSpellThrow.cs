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
        [SerializeField]
        private AudioSource throwSound;
        private Vector2 direction = Vector2.zero;
        private float throwSpeed;
        private float throwRotation;
        private float maxDistance;
        private float currentDistance = 0;

        public void Start() {
        }
        public void Update() {
            Vector2 translation = direction * throwSpeed * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, throwRotation * Time.deltaTime));
            transform.Translate(translation);
            currentDistance += translation.magnitude;
            if (currentDistance > maxDistance) {
                GameObject splashSpellExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform.parent).gameObject;
                splashSpellExplosion.GetComponent<SplashSpellExplosion>().Cast(spell);
                Destroy(gameObject);
            }
        }

        public void Cast(SplashSpellType splashSpell, Vector2 castPosition)
        {
            base.Cast(splashSpell);
            throwRotation = Random.Range(0, 90) - 45;
            currentDistance = 0;
            throwSpeed = splashSpell.ThrowSpeed;
            Vector2 distance = castPosition - (Vector2)transform.position;
            maxDistance = Mathf.Min(splashSpell.Range, distance.magnitude);
            direction = distance.normalized;
            if (throwSound != null) {
                throwSound.Play();
            }
        }
    }
}
