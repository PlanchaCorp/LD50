using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public abstract class GenericSpell : MonoBehaviour
    {
        protected AbstractSpellType spell;

        protected List<GameObject> alliesInRange;
        protected SpriteRenderer spriteRenderer;
        protected Collider2D collider2d;
        private float endTime = 0;
        private void Awake() {
            alliesInRange = new List<GameObject>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            collider2d = GetComponent<Collider2D>();
        }

        private ContactFilter2D contact;
        public void Cast(AbstractSpellType spellType) {
            spell = spellType;
            List<Collider2D> colliders = new List<Collider2D>();
            Physics2D.OverlapCollider(collider2d, contact, colliders);
            foreach (Collider2D collider in colliders) {
                if (collider.CompareTag("Ally")) {
                    alliesInRange.Add(collider.gameObject);
                }
            }
        }

        void FixedUpdate()
        {
            if (endTime != 0 && Time.time > endTime)
            {
                Destroy(gameObject);
            }
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            if ("Ally".Equals(collider.tag))
            {
                alliesInRange.Add(collider.gameObject);
            }
        }
        public void OnTriggerExit2D(Collider2D collider)
        {
            if ("Ally".Equals(collider.tag))
            {
                this.alliesInRange.Remove(collider.gameObject);
            }
        }
    }
}
