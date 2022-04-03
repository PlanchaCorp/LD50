using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts
{
    public class AllyLifeManager : MonoBehaviour
    {
        [SerializeField]
        private GameEventPublisher allyDeath;
        [SerializeField]
        private FloatVariable maxHealth;
        public float currentHealth;

        void Start()
        {
            this.currentHealth = this.maxHealth.Value;
        }

        void Update()
        {
            if(this.currentHealth<=0){
                Die();
            }
        }
        public void Hurt(GameEvent gameEvent) {
            float damage = (float)gameEvent.Get();
            this.currentHealth = this.currentHealth - damage;
        }
        public void Heal(float healingAmount) {
            this.currentHealth = this.currentHealth + healingAmount;
            if (this.currentHealth > maxHealth.Value) {
                this.currentHealth = maxHealth.Value;
            }
        }
        public void Die(){
            GameEvent deathEvent = new GameEvent(this);
            allyDeath.Raise(deathEvent);
            Destroy(gameObject);
        }
    }
}
