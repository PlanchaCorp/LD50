using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AllyLifeManager : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable maxHealth;
        
        [SerializeField]
        private GameEventPublisher allyDeath;
        [SerializeField]
        private GameEventPublisher expEmit;
        [SerializeField]
        private AudioSource[] deathSounds;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public float currentHealth;
        private HealthBar healthBar;

        private float deathTime;
        private bool isDying;

        void Start()
        {
            this.currentHealth = this.maxHealth.Value;
            this.healthBar = GetComponentInChildren<HealthBar>();
            isDying = false;
            deathTime = 0;
        }

        void Update()
        {
            this.healthBar.UpdateSlider(currentHealth,maxHealth.Value);
            if(this.currentHealth<=0){
                Die();
            }
            if (isDying) {
                deathTime += Time.deltaTime;
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
            this.healthBar.showHeal(Mathf.CeilToInt(healingAmount));
            expEmit.Raise(new GameEvent(xpGain));
        }

        public void Die(){
            GameEvent deathEvent = new GameEvent(this);
            allyDeath.Raise(deathEvent);
            StartCoroutine(Die(2));
        }

        public IEnumerator Die(float delay) {
            float opacity = Mathf.Lerp(delay, 0, deathTime);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);
            if (deathSounds.Length > 0) {
                int randomSoundId = Mathf.FloorToInt(Random.Range(0, deathSounds.Length - 0.01f));
                deathSounds[randomSoundId].Play();
            }
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }
    }
}
