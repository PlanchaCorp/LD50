using UnityEngine;
using UnityEngine.InputSystem;
using PlanchaCorp.LD50.ScriptableObjects;

namespace PlanchaCorp.LD50.Scripts.Player {
[RequireComponent(typeof(Rigidbody2D))]
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable speed;
        [SerializeField]
        private Vector2Variable position;
        [SerializeField]
        private SpellBook spellBook;
        [SerializeField]
        private GameEventPublisher auraSpellEvent;
        [SerializeField]
        private GameEventPublisher spikeSpellEvent;
        [SerializeField]
        private GameEventPublisher splashSpellEvent;
        [SerializeField]
        private GameEventPublisher raySpellEvent;
        private Rigidbody2D rb;
        private Vector2 direction = Vector2.zero;

        public void Start(){
            rb = GetComponent<Rigidbody2D>();
            CastPassiveSpell();
        }
        public void OnMove (InputValue input){
            this.direction = input.Get<Vector2>().normalized;
        }
        public void FixedUpdate(){
            this.rb.velocity = direction * speed.Value;
            this.position.Value = this.gameObject.transform.position;
        }

        public void OnSkill1() {
            // Do nothing, because this is the passive action run from the start
        }

        public void OnSkill2()
        {
            // GameEvent spellEvent = new GameEvent(this);
            // spikeSpellEvent.Raise(spellEvent);
            Debug.Log("Skill 2");
        }

        public void OnSkill3()
        {
            // GameEvent spellEvent = new GameEvent(this);
            // splashSpellEvent.Raise(spellEvent);
            Debug.Log("Skill 3");
        }

        public void OnSkill4()
        {
            // GameEvent spellEvent = new GameEvent(this);
            // raySpellEvent.Raise(spellEvent);
            Debug.Log("Skill 4");
        }

        private void CastPassiveSpell(){
            GameEvent spellEvent = new GameEvent(this);
            auraSpellEvent.Raise(spellEvent);
        }
    }
}
