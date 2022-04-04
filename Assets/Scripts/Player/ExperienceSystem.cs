using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Player
{
    public class ExperienceSystem : MonoBehaviour
    {
        [SerializeField]
        private IntVariable maxXpPerLevel;
        [SerializeField]
        private FloatVariable xpRequiredScaling;

        [SerializeField]
        public IntVariable AvailableSkillPoints;
        [SerializeField]
        private FloatVariable experienceAmount;
        [SerializeField]
        private IntVariable levelAmount;

        [SerializeField]
        private GameEventPublisher expRender;
        [SerializeField]
        private GameEventPublisher levelUpEvent;

        public void Update(){
            expRender.Raise(new GameEvent((float)experienceAmount.Value/(float)maxXpPerLevel.Value));
        }

        public void GainExperience(GameEvent gainExperienceEvent) {
            experienceAmount.Value = experienceAmount.Value + (float)gainExperienceEvent.Get();
            if(experienceAmount.Value>=maxXpPerLevel.Value) {
                levelUpEvent.Raise(new GameEvent());
            }
        }
        public void OnLevelUp(){
            this.levelAmount.Value++;
            this.experienceAmount.Value = 0;
            this.AvailableSkillPoints.Value = this.AvailableSkillPoints.Value +1;
            this.maxXpPerLevel.Value = Mathf.CeilToInt(maxXpPerLevel.DefaultValue * Mathf.Pow( xpRequiredScaling.Value , (float) levelAmount.Value));
        }
        public void OnSpellUpgraded(){
            this.AvailableSkillPoints.Value--;
        }
    }
}
