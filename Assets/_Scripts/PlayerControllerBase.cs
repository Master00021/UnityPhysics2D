using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerControllerBase : MonoBehaviour
    {
        private Rigidbody2D playerRigidBody2D;
        //[SerializeField] private CheckpointsManager _checkPointsManager;
        private float _horizontalAxis, _verticalAxis;
        //[SerializeField] private int _cards = 0;

        private void Awake() {
            
            playerRigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Update() {

            _horizontalAxis = Input.GetAxis("Horizontal");
            _verticalAxis = Input.GetAxis("Vertical");
        }

        /*private void OnTriggerEnter2D(Collider2D other) {
            
            if (other.CompareTag("CheckPoint")) {

                int checkpointIndex = other.gameObject.GetComponent<CheckPoint>().checkpointIndex;

                if (_checkPointsManager == null) 
                    return;

                _checkPointsManager.ActivateCheckPoint(checkpointIndex);
            }
        }*/

        internal float GetHorizontalAxis() {

            return _horizontalAxis;
        }

        internal float GetVerticalAxis() {

            return _verticalAxis;
        }

        internal Rigidbody2D GetPlayerRB2D() {

            return playerRigidBody2D;
        }

        /*internal void SetCard(int newCard) {

            _cards += Mathf.Abs(newCard);
        }*/
    }
