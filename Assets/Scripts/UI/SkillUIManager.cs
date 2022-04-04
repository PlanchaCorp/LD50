using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    [SerializeField]
    private Image cooldownMask;
    [SerializeField]
    private Image selectionMask;
    [SerializeField]
    private Image lockMask;
    [SerializeField]
    private TMPro.TMP_Text timer;

    private Button spellButton;

    void Start() {
        spellButton = GetComponent<Button>();
    }
    void Update(){
    }
    public void setClickable() {
        spellButton.interactable = true;
        lockMask.enabled = false;
    }
    public void coolDown(float delay) {
        spellButton.interactable = false;
        StartCoroutine("coolDownProgress",delay);
    }
    public void Equip(){
        if(spellButton.interactable){
            selectionMask.enabled = true;
        }
    }
    public void UnEquip(){
        selectionMask.enabled = false;
    }
    public void OnSpellCasted(GameEvent gameEvent){
        AbstractSpellType spellType = gameEvent.Get<AbstractSpellType>();
        spellButton.interactable = false;
        this.coolDown(spellType.Cooldown);
    }
    public void setNotClickable() {
        spellButton.interactable = false;
        lockMask.enabled = true;
    }
    IEnumerator coolDownProgress(float delay){
        for(float time = 0;time <= delay;time += .1f) {
            cooldownMask.fillAmount = 1 - (time/delay);
            timer.text = "" + Mathf.Ceil(delay - time);
            yield return new WaitForSeconds(.1f);
        }
        timer.text = "";
        spellButton.interactable = true;

    }
}
