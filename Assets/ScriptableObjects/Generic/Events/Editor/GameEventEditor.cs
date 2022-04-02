// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;
using PlanchaCorp.LD50.ScriptableObjects;

namespace RoboRyanTron.Unite2017.Events
{
    [CustomEditor(typeof(GameEventPublisher), editorForChildClasses: true)]
    public class GameEventPublisherEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEventPublisher e = target as GameEventPublisher;
            if (GUILayout.Button("Raise"))
                e.Raise(new GameEvent(0));
        }
    }
}