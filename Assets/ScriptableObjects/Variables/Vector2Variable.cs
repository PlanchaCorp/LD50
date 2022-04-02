using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanchaCorp.LD50.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Vector2 Variable")]
    public class Vector2Variable : ScriptableObject
    {
        [SerializeField]
        public Vector2 Value;
    }
}
