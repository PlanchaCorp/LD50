using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class GenericSpell : MonoBehaviour
    {
        protected AbstractSpellType spell;

        protected List<GameObject> alliesInRange;
        protected SpriteRenderer spriteRenderer;
        private float endTime = 0;
        private void Awake() {
            alliesInRange = new List<GameObject>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Cast(AbstractSpellType spellType) {
            spell = spellType;
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
