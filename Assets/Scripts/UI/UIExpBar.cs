using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts{
}
public class UIExpBar : MonoBehaviour
{
    private Slider expBar;
    // Start is called before the first frame update
    void Start()
    {
        this.expBar = this.GetComponent<Slider>();
    }

    public void Progress(GameEvent amount){
        this.expBar.value = (float)amount.Get();
    }
}
    
