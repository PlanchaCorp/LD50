using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Float Variable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField]
        public float Value;
    }
}
