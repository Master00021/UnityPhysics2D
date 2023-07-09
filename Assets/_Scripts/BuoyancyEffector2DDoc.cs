using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyancyEffector2DDoc : MonoBehaviour
{
    /*

        Use Collider Mask ...

        Density, es la 'densidad' del fluido, cuanto mayor sea su valor, mas pegagoso y engorroso pasar a travez del Effector,
        mientras menor sea su valor, mas flotara y mas facilmente sera parar a travez deel Effector. Y los que posean la misma
        densidad, apareceran suspendidos en el fluido.

        Surface Level, Esto es en donde estara la linea delimitadora del fluido, es decir, donde se empezara a hacer el efecto de 
        estabilizarse en el fluido. 
        Si el valor es mayor a la altura del collider, el effector seguira funcionando como se esperaria, hasta que el collider
        del gameObject que interactua con el, salga del collider del effector. Lo mismo para un valor menor a la alturra del collider.

        Damping ...

        Apartado de Flow:

            Flow Angle, esto definira hacia donde ira la 'corriente? del fluido, si es 0, ira hacia Vector2.right; si es -180, ira a Vector2.left.
            Si es 90, ira hacia arriba, como si el fluido expulsara al gameObject que entro dentro de él.
            Si es -90, el gamoObject se vera arrastrado a la profundidad del effector.

            Flow Magnitude, la fuerza de la corriente del fluido.
            Flow Variation, varia mientras este dentro, no solamente cuando entre y sale

    */

    private BuoyancyEffector2D BE2D;
    [SerializeField] private PlayerControllerBase _player;

    private void Awake() {
        
        BE2D = GetComponent<BuoyancyEffector2D>();
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.CompareTag("Player")) {

            //BE2D.surfaceLevel = _player.gameObject.transform.localPosition.y;
        }
    }
}
