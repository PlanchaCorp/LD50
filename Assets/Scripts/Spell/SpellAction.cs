using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace PlanchaCorp.LD50.Scripts.Spell {
    public class SpellAction : MonoBehaviour
    {
        private float endTime;
        private float amount;
        private float duration;
        private List<GameObject> entities;
        // Start is called before the first frame update
        void Awake()
        {
            entities = new List<GameObject>();
        }
        // Update is called once per frame
        void Update()
        {
            if(duration != 0 && Time.time > endTime ){
                Destroy(gameObject);
            }
        }

        public void cast(float duration,float amount,float scale){

            this.transform.localScale *= scale;
            this.amount = amount;
            this.duration = duration;
            if (duration > 0) {
                endTime = Time.time + duration;
            }
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
