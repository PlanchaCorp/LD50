using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanchaCorp.LD50.ScriptableObjects {

    [CreateAssetMenu(menuName = "Scriptable Objects/Spawn Setting")]
    public class SpawnSetting : ScriptableObject
    {
        public float minRange;
        public float maxRange;

        public float spawnRate;
        public float spawnRateEvolution;
    }
}
