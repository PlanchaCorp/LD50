using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts
{
    public class Plague : MonoBehaviour
    {
        [SerializeField]
        private GameEvent plagueEvent;

        [SerializeField]
        private FloatVariable dpsAtStart;
        [SerializeField]
        private FloatVariable dpsIncrease;

        private float dps;

        public void Start() {
            dps = dpsAtStart.Value;   
        }

        public void FixedUpdate() {
            if (gameObject.activeSelf) {
                dps += dpsIncrease.Value * Time.fixedDeltaTime;
            }
        }

        public void Decay(GameEvent clockTickEvent) {
            plagueEvent.floatValue = dps * clockTickEvent.floatValue;
            plagueEvent.Raise();
        }
    }
}
