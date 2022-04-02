using System;

namespace PlanchaCorp.LD50.ScriptableObjects
{
    public class GameEvent
    {
        private Object Value;

        public GameEvent(Object value) {
            this.Value = value;
        }
        public void Set<T>(T obj) where T : class
        {
            this.Value = obj;
        }
        public T Get<T>() where T : class
        {
            return (T)Value;
        }

        public void Set(System.Object obj)
        {
            this.Value = obj;
        }
        public System.Object Get()
        {
            return Value;
        }
    }
}
