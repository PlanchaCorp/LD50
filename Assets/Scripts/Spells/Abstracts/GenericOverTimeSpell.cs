using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class GenericOverTimeSpell : GenericSpell
    {
        protected AbstractSpellType spellType;
        public void recast(AbstractSpellType spellType){
            this.spellType = spellType;
        }
        private ContactFilter2D contact;
        public new void Cast(AbstractSpellType spellType)
        {
            base.Cast(spellType);
            this.spellType = spellType;
            List<Collider2D> colliders = new List<Collider2D>();
            Physics2D.OverlapCollider(collider2d, contact, colliders);
            foreach (Collider2D collider in colliders) {
                if (collider.CompareTag("Ally")) {
                    this.alliesInRange.Add(collider.gameObject);
                }
            }
        }

        public void HealAllies(GameEvent clockTickEvent)
        {
            this.alliesInRange.ForEach(delegate (GameObject gameObject)
            {
                if(gameObject != null){
                    AllyLifeManager allyLifeManager = gameObject.GetComponent<AllyLifeManager>();
                    if (allyLifeManager != null)
                    {
                        allyLifeManager.Heal((float)clockTickEvent.Get() * spell.HealAmount);
                    }
                }
            });
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
