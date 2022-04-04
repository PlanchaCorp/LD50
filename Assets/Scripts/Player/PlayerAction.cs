using UnityEngine;
using UnityEngine.InputSystem;
using PlanchaCorp.LD50.ScriptableObjects;
using static PlanchaCorp.LD50.Scripts.Spells.SpellNumbers;

namespace PlanchaCorp.LD50.Scripts.Player {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable speed;
        [SerializeField]
        private Vector2Variable position;
        [SerializeField]
        private GameEventPublisher preUpgradeEvent;
        [SerializeField]
        private GameEventPublisher selectEvent;
        [SerializeField]
        private GameEventPublisher preCastEvent;
        private Rigidbody2D rb;
        private Vector2 direction = Vector2.zero;
        private SpellCaster spellCaster;
        private AudioSource footstepSound;
        private SpriteRenderer renderer;
        private Animator animator;

        public void Start(){
            rb = GetComponent<Rigidbody2D>();
            spellCaster = GetComponentInChildren<SpellCaster>();
            footstepSound = GetComponent<AudioSource>();
            renderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }
        public void OnMove (InputValue input){
            this.direction = input.Get<Vector2>().normalized;
            animator.SetFloat("speed",this.direction.magnitude);
            Debug.Log(direction.x);
            if(direction.x>0){
                renderer.flipX =false;
            } else if(direction.x<0) {
                renderer.flipX =true;
            }
            if (footstepSound != null) {
                footstepSound.volume = direction != Vector2.zero ? 1 : 0;
            }
        }
        public void FixedUpdate(){
            this.rb.velocity = direction * speed.Value;
            this.position.Value = this.gameObject.transform.position;
        }

        // Input callbacks
        public void OnSkill1(InputValue input)
        {
            // Do nothing, because this is the passive action run from the start
        }
        public void OnSkill1Upgrade() {
            preUpgradeEvent.Raise(new GameEvent(AURA));
        }
        public void OnSkill2(InputValue input)
        {
            var front =input.Get<float>();
            if(front >= .5f){
                selectEvent.Raise(new GameEvent(SPIKE));
            }
            if(front < .5f){
                preCastEvent.Raise(new GameEvent());
            }
        }
        public void OnSkill2Upgrade()
        {
            preUpgradeEvent.Raise(new GameEvent(SPIKE));
        }
        public void OnSkill3(InputValue input)
        {
            var front =input.Get<float>();
            if(front >= .5f){
                selectEvent.Raise(new GameEvent(RAY));
            }
            if(front < .5f){
                preCastEvent.Raise(new GameEvent());
            }
        }
        public void OnSkill3Upgrade()
        {
            preUpgradeEvent.Raise(new GameEvent(RAY));
        }
        public void OnSkill4(InputValue input)
        {
            var front =input.Get<float>();
            if(front >= .5f){
                selectEvent.Raise(new GameEvent(SPLASH));
            }
            if(front < .5f){
                preCastEvent.Raise(new GameEvent());
            }
        }
        public void OnSkill4Upgrade()
        {
            preUpgradeEvent.Raise(new GameEvent(SPLASH));
        }

        public void OnFire() 
        {
            preCastEvent.Raise(new GameEvent());
        }
    }
}
