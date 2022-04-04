using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public abstract class GenericSpell : MonoBehaviour
    {
        protected AbstractSpellType spell;

        protected SpriteRenderer spriteRenderer;
        protected Collider2D collider2d;
        protected List<GameObject> alliesInRange;
        private float endTime = 0;
        private void Awake() {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            alliesInRange = new List<GameObject>();
            collider2d = GetComponent<Collider2D>();
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
    }
}
