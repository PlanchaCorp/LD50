using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

public class SpellsManager : MonoBehaviour
{
    [SerializeField]
    private SpellBook spellBook;
    // Start is called before the first frame update
    [SerializeField]
    private List<SkillUIManager> skills;
    void Start()
    {
    }
    void Update(){
        
    }
    public void onLevelUp(){
        Debug.Log("onLevelUp");
        DisplayUpgrades();
    }

    void DisplayUpgrades(){
        if(spellBook.AuraNextLevelExist()){
            skills[0].DisplayUpgradeButton();
        }
        if(spellBook.SpikeNextLevelExist()){
            skills[1].DisplayUpgradeButton();
        }
        if(spellBook.RayNextLevelExist()){
            skills[2].DisplayUpgradeButton();
        }
        if(spellBook.SplashNextLevelExist()){
            skills[3].DisplayUpgradeButton();
        }
    }
    public void hidesUpgrades(){
        if(spellBook.availableSkillPoints.Value==0){
        skills.ForEach(delegate(SkillUIManager skillUIManager){
            skillUIManager.HideUpgradeButton();
        });
        }
    }

    public void OnSpellCasted(GameEvent gameEvent){
        var spell = gameEvent.Get();
        if(spell.GetType()==typeof(SplashSpellType)){
            skills[3].coolDown(((SplashSpellType)spell).Cooldown);
        }
    }

    // Update is called once per frame
    public void UpgradeAura(){
        spellBook.UpgradeAura();
        hidesUpgrades();
    }
        public void UpgradeSpike(){
        spellBook.UpgradeSpike();
        hidesUpgrades();

    }
    public void UpgradeRay(){
        spellBook.UpgradeRay();
        hidesUpgrades();
    }
        public void UpgradeSplash(){
        spellBook.UpgradeSplash();
        hidesUpgrades();
    }
}
