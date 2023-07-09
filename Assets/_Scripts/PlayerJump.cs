using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerJump : PlayerControllerBase
    {
        // SOLO Salto
        
        [SerializeField] internal float jumpForce;
        [SerializeField] internal float gravityForce;
        [SerializeField] internal int _jumpCounter;
        
        private float maxGravityScale = 4f;

        private PlayerControllerBase PCBase;
        //private PlayerWind PlayerWind;
        

        private void Awake() {
            
            PCBase = GetComponent<PlayerControllerBase>();
            //PlayerPropulsor = GetComponent<PlayerLadder>();
            //PlayerWind = GetComponent<PlayerWind>();
        }

        private void Update() {

            if (IsGrounded()) {

                PCBase.GetPlayerRB2D().gravityScale = 1f;

                _jumpCounter = 1;
                //PlayerPropulsor.IsOut = false;
            }
            
            if (Input.GetKeyDown(KeyCode.Space)  && _jumpCounter > 0/* && !PlayerWind.InWind && !PlayerPropulsor.GetInLadder()*/) {

                Jump();
            }

            if (_jumpCounter <= 2 /*|| PlayerPropulsor.IsOut || !PlayerWind.InWind*/) 
                GravityWeight(); 

            // Other Mechanic

            if (_onObjectJump) {

                PCBase.GetPlayerRB2D().velocity = new Vector2(0f, PCBase.GetPlayerRB2D().velocity.y);

                _timer -= Time.deltaTime;
            }

            if (_timer < 0f) {

                _onObjectJump = false;
                _timer = 2f;
            }
        }

        private void Jump() {

            PCBase.GetPlayerRB2D().gravityScale = 1f;
            PCBase.GetPlayerRB2D().velocity = new Vector2(PCBase.GetPlayerRB2D().velocity.x, 0f); // Physics Reset
            
            PCBase.GetPlayerRB2D().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Actual Jump

            _jumpCounter--;

            if (_jumpCounter <= 0)
                _jumpCounter = 0;
        }  

        internal void GravityWeight() {

            PCBase.GetPlayerRB2D().gravityScale += gravityForce * Time.deltaTime;

            if (PCBase.GetPlayerRB2D().gravityScale > maxGravityScale) {

                PCBase.GetPlayerRB2D().gravityScale = maxGravityScale;
            }
        }

        internal int GetJumpCounter() {

            return _jumpCounter;
        }

        private bool IsGrounded() {

            var hit =  Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("Ground"));

            return hit.collider is not null;
        }

        // Other Mechanic

        [SerializeField] private float _timer;
        private bool _onObjectJump;
/*
        private void OnTriggerStay2D(Collider2D other) {
            
            if (other.gameObject.CompareTag("Fly")) {

                ObjectJump();
            }
        }
*/
        private void ObjectJump() {

            _timer = 2f;

            PCBase.GetPlayerRB2D().velocity = new Vector2(0f, 0f);

            _onObjectJump = true;

            PCBase.GetPlayerRB2D().AddForce(new Vector2(0f, 2000f));
        }
    }