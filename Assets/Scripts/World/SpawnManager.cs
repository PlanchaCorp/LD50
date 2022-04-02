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
        [SerializeField]
        private SpawnSetting spawnSetting;
        private int tick = 0;
        void Start()
        {

        }

        public void OnTick(){
            tick++;
            if(tick%spawnSetting.spawnRate == 0){
                Vector2 pos = Random.insideUnitCircle.normalized * Random.Range(spawnSetting.minRange,spawnSetting.maxRange);
                Instantiate(ally,playerPosition.Value + pos,Quaternion.identity);
            }
        }
    }
}

