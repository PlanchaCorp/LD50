using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace PlanchaCorp.LD50.Scripts.Spell {
    public class SpellAction : MonoBehaviour
    {
        private float endTime;
        private float amount;
        private List<GameObject> entities;
        // Start is called before the first frame update
        void Awake()
        {
            entities = new List<GameObject>();
            cast(3,15,1);
        }
        // Update is called once per frame
        void Update()
        {
            if(Time.time > endTime ){
                Destroy(gameObject);
            }
        }

        void cast(float duration,float amount,float scale){
            endTime = Time.time + duration;
            this.transform.localScale *= scale;
            this.amount = amount;
        }

        public void OnTriggerEnter2D(Collider2D collider){
        }
        public void OnTriggerExit2D(Collider2D collider){

        }
        public void HealAllies(){
            Debug.Log("heal" + amount);
        }
    }
}
