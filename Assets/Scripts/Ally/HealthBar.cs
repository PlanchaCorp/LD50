using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlanchaCorp.LD50.Scripts {
    public class HealthBar : MonoBehaviour {

        private Slider slider;
        private Canvas canvas;
        private TMPro.TMP_Text text;

        void Start(){
            slider = GetComponentInChildren<Slider>();
            canvas = GetComponent<Canvas>();
            text = GetComponentInChildren<TMPro.TMP_Text>();
            canvas.worldCamera = Camera.main;
        }
        public void UpdateSlider(float current,float total){
            slider.value = current/total;
        }
        public void showHeal(int amount){
            var color = this.text.color;
            color.a = 1f;
            this.text.text = "+" + amount;
            this.text.color = color;
            StartCoroutine("fadeText");
        }

        IEnumerator fadeText(){
            for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
            {
            var color = this.text.color;
            color.a = alpha;
            this.text.color = color;
            yield return new WaitForSeconds(.1f);
        }
        }
    }
}
