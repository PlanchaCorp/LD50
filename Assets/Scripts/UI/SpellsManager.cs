using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;
using PlanchaCorp.LD50.Scripts.Spells;
using static PlanchaCorp.LD50.Scripts.Spells.SpellNumbers;

public class SpellsManager : MonoBehaviour
{
    [SerializeField]
    private SpellBook spellBook;
    [SerializeField]
    private IntVariable skillPoint;
    [SerializeField]
    private GameEventPublisher preUpgradeEvent;
    [SerializeField]
    private List<SkillUIManager> skills;
    [SerializeField]
    private List<UpgradeButton> skillsUpgrade;
    [SerializeField]
    private GameObject upgradePanel;
    void Update(){
        if(skillPoint.Value>0) {
            DisplayUpgrades();
        } else {
            HidesUpgrades();
        }
        if(spellBook.EquippedAuraSpell is null){
            skills[0].setNotClickable();
        } else {
            skills[0].setClickable();
        }
        if(spellBook.EquippedRaySpell is null){
            skills[2].setNotClickable();
        } else {
            skills[2].setClickable();
        }
        if(spellBook.EquippedSpikeSpell?.Level is null){
            skills[1].setNotClickable();
        } else {
            skills[1].setClickable();
        }
        if(spellBook.EquippedSplashSpell?.Level is null){
            skills[3].setNotClickable();
        } else {
            skills[3].setClickable();
        }
    }

    void DisplayUpgrades(){
        upgradePanel.SetActive(true);
        if(spellBook.AuraNextLevelExist()){
            skillsUpgrade[0].activeButton();
        }
        if(spellBook.SpikeNextLevelExist()){
            skillsUpgrade[1].activeButton();
        }
        if(spellBook.RayNextLevelExist()){
            skillsUpgrade[2].activeButton();
        }
        if(spellBook.SplashNextLevelExist()){
            skillsUpgrade[3].activeButton();
        }
    }
    public void HidesUpgrades(){
        skillsUpgrade.ForEach(delegate(UpgradeButton upgradeButton){
            upgradeButton.disableButton();
        });
        upgradePanel.SetActive(false);
    }

    public void OnSpellCasted(GameEvent gameEvent){
        var spell = gameEvent.Get();
        if(spell.GetType()==typeof(SplashSpellType)){
            skills[3].coolDown(((SplashSpellType)spell).Cooldown);
            skills[3].UnEquip();
        }
        if(spell.GetType()==typeof(RaySpellType)){
            skills[2].coolDown(((RaySpellType)spell).Cooldown);
            skills[2].UnEquip();
        }
        if(spell.GetType()==typeof(SpikeSpellType)){
            skills[1].coolDown(((SpikeSpellType)spell).Cooldown);
            skills[1].UnEquip();
        }
    }
    public void OnSpellSelected(GameEvent gameEvent){
        var spell = (SpellNumbers)gameEvent.Get();
        skills.ForEach(delegate(SkillUIManager skillUIManager){
            skillUIManager.UnEquip();
        });
        switch(spell){
            case SPIKE:
                skills[1].Equip();
                break;
            case RAY:
                skills[2].Equip();
                break;
            case SPLASH:
                skills[3].Equip();
                break;
        }
    }
    public void UpgradeAura(){
        preUpgradeEvent.Raise(new GameEvent(AURA));
    }
        public void UpgradeSpike(){
        preUpgradeEvent.Raise(new GameEvent(SPIKE));
    }
    public void UpgradeRay(){
        preUpgradeEvent.Raise(new GameEvent(RAY));
    }
    public void UpgradeSplash(){
        preUpgradeEvent.Raise(new GameEvent(SPLASH));
        
    }

}
