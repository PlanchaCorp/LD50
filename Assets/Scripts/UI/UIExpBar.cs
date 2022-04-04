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
    private TMPro.TMP_Text text;
    [SerializeField]
    private IntVariable level;
    // Start is called before the first frame update
    void Start()
    {
        this.expBar = this.GetComponent<Slider>();
        this.text = this.GetComponentInChildren<TMPro.TMP_Text>();
    }

    void Update(){
        this.text.text = "" + level.Value;
    }
    public void Progress(GameEvent amount){
        this.expBar.value = (float)amount.Get();
    }
}
    
