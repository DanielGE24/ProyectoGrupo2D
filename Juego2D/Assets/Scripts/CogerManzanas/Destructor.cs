using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    int contadorMuertes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rehen"))
        {
            Destroy(collision.gameObject);
            contadorMuertes++;
            if (contadorMuertes >=5)
            {
                //pierdes
                //capar movimiento
                //dejar de instanciar rehenes
            }
            else if (contadorMuertes <=5) //&& tiempo >=60)
            {
                //ganas
                //capar el movimiento
            }
        }
    }
}
