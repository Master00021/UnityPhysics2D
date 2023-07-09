using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerMovement : PlayerControllerBase
    {
        // SOLO Movimiento
        [SerializeField] internal float speed, acceleration, decelerationF, maxSpeed;

        private PlayerControllerBase PCBase;
        private PlayerJump PlayerJump;
        //private PlayerWind PlayerWind;

        private void Awake() {
            
            PCBase = GetComponent<PlayerControllerBase>();
            PlayerJump = GetComponent<PlayerJump>();
            //PlayerWind = GetComponent<PlayerWind>();
        }

        private void Update() {
            
            if (PCBase.GetHorizontalAxis() != 0f /*&& !PlayerWind.InWind*/) 
                Movement();
            else speed = 0f;
        }

        private void Movement() {

            if (speed < 1500f) // Velocidad movimiento base
                speed = 1500f;

            speed += acceleration * Time.deltaTime;

            PCBase.GetPlayerRB2D().AddForce(new Vector2(PCBase.GetHorizontalAxis() * speed * Time.deltaTime, 0f)); // Aumento velocidad movimiento

            if (PCBase.GetPlayerRB2D().velocity.x >= maxSpeed)
                PCBase.GetPlayerRB2D().velocity = new Vector2(maxSpeed, PCBase.GetPlayerRB2D().velocity.y); 
            if (PCBase.GetPlayerRB2D().velocity.x <= -maxSpeed)
                PCBase.GetPlayerRB2D().velocity = new Vector2(-maxSpeed, PCBase.GetPlayerRB2D().velocity.y); // Limite velocidad movimiento

            if (PCBase.GetHorizontalAxis() >= -0.05f && PCBase.GetHorizontalAxis() <= 0.05f     // Si ya dejo de aumentar el valor de HorizontalAxis
                && PCBase.GetPlayerRB2D().velocity.magnitude > 0f                               // Si la magnitud todavia no es cero
                && PlayerJump.GetJumpCounter() == 2) {                                          // Si esta en el suelo

                    float deceleration = decelerationF * Mathf.Pow(PCBase.GetPlayerRB2D().velocity.magnitude, 2f); // Mas lejos de cero, mas desaceleracion

                    PCBase.GetPlayerRB2D().AddForce(new Vector2(-(PCBase.GetPlayerRB2D().velocity.normalized.x) * deceleration * Time.deltaTime, 0f));
            }
        }
    }

