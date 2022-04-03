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
        private Rigidbody2D rb;
        private Vector2 direction = Vector2.zero;
        private SpellCaster spellCaster;

        public void Start(){
            rb = GetComponent<Rigidbody2D>();
            spellCaster = GetComponentInChildren<SpellCaster>();
        }
        public void OnMove (InputValue input){
            this.direction = input.Get<Vector2>().normalized;
        }
        public void FixedUpdate(){
            this.rb.velocity = direction * speed.Value;
            this.position.Value = this.gameObject.transform.position;
        }

        // Input callbacks
        public void OnSkill1()
        {
            // Do nothing, because this is the passive action run from the start
        }
        public void OnSkill2()
        {
            spellCaster.CastSpikeSpell();
        }
        public void OnSkill3()
        {
            spellCaster.CastSplashSpell();
        }
        public void OnSkill4()
        {
            spellCaster.CastRaySpell();
        }
    }
}
