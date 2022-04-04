using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Spells
{
    public class AuraSpell : GenericOverTimeSpell
    {
    public void Update()
        {
            this.transform.localScale = new Vector3(base.spellType.Range,base.spellType.Range,1);
        }
        public void OnSpellUpgrade(GameEvent gameEvent){
            var spell = gameEvent.Get();
            if(spell.GetType()==typeof(AuraSpellType)){
                base.recast((AuraSpellType) spell);
            }
        }
    }

}
