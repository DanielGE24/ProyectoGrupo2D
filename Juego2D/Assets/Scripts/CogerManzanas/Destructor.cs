using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public int contadorMuertes;
    // Start is called before the first frame update
    void Start()
    {
        contadorMuertes = 0;
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
        }
    }
}
