using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts {
    public class ClockTicker : MonoBehaviour
    {

        [SerializeField]
        private FloatVariable tickDelay;
        [SerializeField]
        private GameEventPublisher onTickEvent;
        void OnEnable()
        {
            StartCoroutine("tick");
        }
        void OnDisable(){
            StopCoroutine("tick");
        }
        IEnumerator tick(){
            for(;;) {
                GameEvent tickEvent = new GameEvent(tickDelay.Value);
                onTickEvent.Raise(tickEvent);
                yield return new WaitForSeconds(tickDelay.Value);
            }
        }
    }
}
