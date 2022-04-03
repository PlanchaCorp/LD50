using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExpBar : MonoBehaviour
{
    private Slider expBar;
    // Start is called before the first frame update
    void Start()
    {
        this.expBar = this.GetComponent<Slider>();
    }

    public void progress(float amount,float total){
        this.expBar.value = amount/total;
    }
}
