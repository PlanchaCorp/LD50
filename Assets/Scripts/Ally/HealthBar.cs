using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanchaCorp.LD50.Scripts {
    public class HealthBar : MonoBehaviour {

        private Slider slider;
        private Canvas canvas;

        void Start(){
            slider = GetComponentInChildren<Slider>();
            canvas = GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
        }
        public void UpdateSlider(float current,float total){
            slider.value = current/total;
        }
    }
}
