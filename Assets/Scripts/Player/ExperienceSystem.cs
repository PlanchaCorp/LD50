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
        [SerializeField]
        public IntVariable AvailableSkillPoints;
        [SerializeField]
        private GameEventPublisher expRender;
        [SerializeField]
        private GameEventPublisher levelUpEvent;

        public void Update(){
            expRender.Raise(new GameEvent((float)experienceAmount.Value/(float)maxXpPerLevel.Value));
        }

        public void GainExperience(GameEvent gainExperienceEvent) {
            experienceAmount.Value = experienceAmount.Value + (int)gainExperienceEvent.Get();
            if(experienceAmount.Value>=maxXpPerLevel.Value) {
                levelUpEvent.Raise(new GameEvent());
            }
        }
        public void OnLevelUp(){
            this.levelAmount.Value ++;
            this.experienceAmount.Value = 0;
            this.AvailableSkillPoints.Value++;
            this.maxXpPerLevel.Value = Mathf.CeilToInt(maxXpPerLevel.DefaultValue * Mathf.Pow( 1.5f , (float) levelAmount.Value));
        }
    }
}
