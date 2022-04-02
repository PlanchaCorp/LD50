using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

public class AllyDecay : MonoBehaviour
{
    [SerializeField]
    private GameEvent onAllyDie;
    public float maxHealth;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.currentHealth<=0){
            Die();
        }
    }
    public void Hurt(GameEvent gameEvent){
        float damage = gameEvent.floatValue;
        this.currentHealth =- damage;
    }
    public void Die(){
        onAllyDie.Raise();
        Destroy(gameObject);
    }
}
