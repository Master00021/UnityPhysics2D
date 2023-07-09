using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffetor2DDoc : MonoBehaviour
{
    /*

        Requerimientos: Necesita usar un collider, que sea trigger y que ademas tenga la opcion "Used by effector" en true. 

        Apartado Use Collider Mask:

            Collider Mask vs Global Collision Matrix:

                El 'Collider Mask' es para definir con que otros colliders chocara/interactuara el objeto que tenga la Collider Mask.
                Es decir, es para modificar las colisiones entre objetos de manera individual.

                La Global Collision Matrix es para definir cuales colliders interactuaran entre ellos, a manera general.
                Es decir, es para modificar las colisiones entre objetos de manera general.

        Apartado Force:

            El angulo hacia donde aplica la fuerza por default es Vector2.right

            Use Global Angle = True, esto definira hacia donde se hara la fuerza, utilizando el angulo global.
            Es decir; 0 = Vector2.right; -90 = Vector2.down; -180 = Vector2.left; -270 = Vector2.up; 

            Use Global Angle = False, esta opcion utilizara el angulo local del gameObject para aplicar la fuerza.

            Force Magnitude, define la cantidad de fuerza que ejercera el Effector.
            Puede ser negativo, invirtiendo el lado hacia el cual ejercera la fuerza.   

            Force Variation, esto es una fuerza extra randomizada que se le aplicara al Force Magnitude, que variarar dentro del numero que eligamos.
            Este calculo sse hara cada vez que otro gameObject collisione con el Effector.

            Force Target, este definira si la fuerza ejercida sera aplicada al RigidBody2D o al Collider2D del gameObject que collisione con el Effector.

        Apartado Damping:

            Drag, esto definira cuanta fuerza se le aplicara al Drag del RigidBody2D del gameObject que collisione con el Effector.

            Angular Drag, esto definira cuanta fuerza se le aplicara al Angular Drag del RigidBody2D del gameObject que collisione con el Effector.
            
    */

    private AreaEffector2D _areaEffector;

    private void Awake() {
        
        _areaEffector = GetComponent<AreaEffector2D>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {

            _areaEffector.forceMagnitude += 5f * Time.deltaTime;

            print(_areaEffector.forceMagnitude);
        }
    }
}
