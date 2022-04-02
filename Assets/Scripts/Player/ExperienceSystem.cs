using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Player
{
    public class ExperienceSystem : MonoBehaviour
    {
        [SerializeField]
        private IntVariable experienceAmount;
        [SerializeField]
        private IntVariable levelAmount;
        [SerializeField]
        private IntVariable maxXpPerLevel;

        public void GainExperience(GameEvent gainExperienceEvent) {
            int xpSum = experienceAmount.Value + gainExperienceEvent.intValue;
            if (maxXpPerLevel.Value > 0 && xpSum > maxXpPerLevel.Value) {
                levelAmount.Value += xpSum / maxXpPerLevel.Value;
            }
            experienceAmount.Value = xpSum % maxXpPerLevel.Value;
        }
    }
}
