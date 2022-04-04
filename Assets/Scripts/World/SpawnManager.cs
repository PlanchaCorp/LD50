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
        [SerializeField]
        private GameEventPublisher allyBirthEvent;
        private float tickSum;
        void Start()
        {
            tickSum = 0;
        }

        public void OnTick(GameEvent gameEvent){
            var tickDelay = (float) gameEvent.Get();
            tickSum += tickDelay;
            if(tickSum >= spawnSetting.spawnRate.Value){
                tickSum = 0;
                Vector2 pos = Random.insideUnitCircle.normalized * Random.Range(spawnSetting.minRange,spawnSetting.maxRange);
                Instantiate(ally,playerPosition.Value + pos,Quaternion.identity);
                allyBirthEvent.Raise(new GameEvent());
                updateRate();
            }
        }
        private void updateRate(){
            spawnSetting.spawnRate.Value = Mathf.Max(spawnSetting.spawnRate.Value + spawnSetting.spawnRateEvolution, spawnSetting.spawnRateMin);
        }
    }
}

