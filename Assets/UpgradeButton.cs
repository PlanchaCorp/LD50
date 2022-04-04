using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeButton : MonoBehaviour
{
    private Button plusButton;
    void Start()
    {
        plusButton = GetComponent<Button>();
    }
    public void activeButton(){
        plusButton.interactable = true;
    }
        public void disableButton(){
        plusButton.interactable = false;
    }
}
