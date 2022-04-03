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

        private void Start()
        {
            animationCurrentTime = 0;
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
                opacity = Mathf.Lerp(afterTime.Value, 0, animationCurrentTime - beforeTime.Value) * maxOpacity.Value;
            }
            else
            {
                Destroy(gameObject);
            }
            animationCurrentTime += Time.deltaTime;
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);
        }

        public void HealAllies() {
            this.alliesInRange.ForEach(delegate (GameObject gameObject)
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
