using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

public class AllyLifeManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent onAllyDie;
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
        float damage = gameEvent.floatValue;
        this.currentHealth = this.currentHealth - damage;
    }
    public void Heal(float healingAmount) {
        this.currentHealth = this.currentHealth + healingAmount;
    }
    public void Die(){
        onAllyDie.Raise();
        Destroy(gameObject);
    }
}
