using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts{
}
public class UIAllyCount : MonoBehaviour
{
    private TextMeshProUGUI allyCountText;

    private int allyTotalCount;
    private int allyAliveCount;

    void Start()
    {
        this.allyCountText = this.GetComponent<TextMeshProUGUI>();

        this.allyTotalCount = 0;
        this.allyAliveCount = 0;
        UpdateCount();
    }

    public void IncrementAllyCount() {
        this.allyTotalCount++;
        this.allyAliveCount++;
        UpdateCount();
    }

    public void DecrementAllyAliveCount() {
        this.allyAliveCount--;
        UpdateCount();
    }

    private void UpdateCount() {
        this.allyCountText.text = this.allyAliveCount + " / " + this.allyTotalCount;
    }
}
    
