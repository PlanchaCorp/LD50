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
        private GameEventPublisher expEmit;
        [SerializeField]
        private FloatVariable maxHealth;
        public float currentHealth;
        private HealthBar healthBar;

        void Start()
        {
            this.currentHealth = this.maxHealth.Value;
            this.healthBar = GetComponentInChildren<HealthBar>();
        }

        void Update()
        {
            this.healthBar.UpdateSlider(currentHealth,maxHealth.Value);
            if(this.currentHealth<=0){
                Die();
            }
        }
        public void Hurt(GameEvent gameEvent) {
            float damage = (float)gameEvent.Get();
            this.currentHealth = this.currentHealth - damage;
        }
        public void Heal(float healingAmount) {
            float newHealth = this.currentHealth + healingAmount;
            float xpGain = healingAmount;
            if (newHealth > maxHealth.Value) {
                newHealth = maxHealth.Value;
                xpGain = maxHealth.Value - this.currentHealth;
            }
            this.currentHealth = newHealth;
            expEmit.Raise(new GameEvent(xpGain));
        }
        public void Die(){
            GameEvent deathEvent = new GameEvent(this);
            allyDeath.Raise(deathEvent);
            Destroy(gameObject);
        }
    }
}
