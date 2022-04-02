using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Int Variable")]
    public class IntVariable : ScriptableObject
    {
        [SerializeField]
        public int Value;

        [SerializeField]
        public bool ResetValueOnStart;
        [SerializeField]
        public int DefaultValue;

        public void OnEnable(){
            if (ResetValueOnStart) {
                Value = DefaultValue;   
            }
        }
    }
}
