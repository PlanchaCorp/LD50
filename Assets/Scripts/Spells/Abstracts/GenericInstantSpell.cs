using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class GenericInstantSpell : GenericSpell
    {
        [SerializeField]
        private FloatVariable beforeTime;
        [SerializeField]
        private FloatVariable afterTime;
        [SerializeField]
        private FloatVariable maxOpacity;

        private float animationCurrentTime;
        private bool hasHealedAlready;

        private void Start()
        {
            animationCurrentTime = 0;
            hasHealedAlready = false;
        }

        private void Update()
        {
            float opacity = 0;
            if (animationCurrentTime < beforeTime.Value)
            {
                opacity = Mathf.Lerp(0, beforeTime.Value, animationCurrentTime) * maxOpacity.Value;
            }
            else if (animationCurrentTime < beforeTime.Value + afterTime.Value)
            {
                if (!hasHealedAlready) {
                    HealAllies();
                    hasHealedAlready = true;
                }
                opacity = Mathf.Lerp(afterTime.Value, 0, animationCurrentTime - beforeTime.Value) * maxOpacity.Value;
            }
            else
            {
                Destroy(gameObject);
            }
            animationCurrentTime += Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);
        }

        private ContactFilter2D contact;
        public void HealAllies() {
            alliesInRange = new List<GameObject>();
            List<Collider2D> colliders = new List<Collider2D>();
            Physics2D.OverlapCollider(collider2d, contact, colliders);
            foreach (Collider2D collider in colliders) {
                if (collider.CompareTag("Ally")) {
                    alliesInRange.Add(collider.gameObject);
                }
            }
            alliesInRange.ForEach(delegate (GameObject gameObject)
            {
                AllyLifeManager allyLifeManager = gameObject.GetComponent<AllyLifeManager>();
                if (allyLifeManager != null)
                {
                    allyLifeManager.Heal(spell.HealAmount);
                }
            });
        }
    }
}
