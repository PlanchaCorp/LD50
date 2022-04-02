
using UnityEngine;
using UnityEngine.Events;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event Publisher to register with.")]
        public GameEventPublisher EventPublisher;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent<GameEvent> Response;

        private void OnEnable()
        {
            if (EventPublisher != null)
            {
                EventPublisher.RegisterListener(this);
            }
        }

        private void OnDisable()
        {
            if (EventPublisher != null)
            {
                EventPublisher.UnregisterListener(this);
            }
        }

        public void OnEventRaised(GameEvent value)
        {
            Response.Invoke(value);
        }
    }
}
