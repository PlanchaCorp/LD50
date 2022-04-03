using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class GenericOverTimeSpell : GenericSpell
    {

        [SerializeField]
        private FloatVariable opacity;
        private float currentTime;

        private void Start()
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity.Value);
        }

        public void Cast(AbstractSpellType spellType, Vector2 castPosition)
        {
            base.Cast(spellType);
        }

        public void HealAllies(GameEvent clockTickEvent)
        {
            this.alliesInRange.ForEach(delegate (GameObject gameObject)
            {
                AllyLifeManager allyLifeManager = gameObject.GetComponent<AllyLifeManager>();
                if (allyLifeManager != null)
                {
                    allyLifeManager.Heal((float)clockTickEvent.Get() * spell.HealAmount);
                }
            });
        }
    }
}
