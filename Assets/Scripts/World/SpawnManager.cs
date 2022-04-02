using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.World {
public class SpawnManager : MonoBehaviour
{
        public GameObject ally;
        [SerializeField]
        private Vector2Variable playerPosition;
        public int tick = 0;
        void Start()
        {

        }

        public void OnTick(){
            tick++;
            if(tick%3 ==0){
                Vector2 pos = Random.insideUnitCircle.normalized * Random.Range(20f,30f);
                Instantiate(ally,playerPosition.Value + pos,Quaternion.identity);
            }
        }
        
    public static Vector2 NextGaussian() {
        float v1, v2, s;
        do {
            v1 = Random.Range(-1f,1f);
            v2 = Random.Range(-1f,1f);
            s = v1 * v1 + v2 * v2;
        } while (s >= 1.0f || s == 0f);

        s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);
        return  new Vector2(v1 * s,v2 * s);
        }
    }
}

