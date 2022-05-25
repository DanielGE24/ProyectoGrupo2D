using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vidas : MonoBehaviour
    
{
    [SerializeField] GameObject vidasxd;
    int vidas = 5;
    int contadorVidas= 1;
    TextMeshProUGUI textoVidas;
    // Start is called before the first frame update
    void Start()
    {

        textoVidas = vidasxd.GetComponent<TextMeshProUGUI>();
        textoVidas.text = "X" + vidas;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            vidas = vidas - contadorVidas;
            textoVidas.text = "X" + vidas;
        } 
        if (collision.gameObject.CompareTag("aire"))
        {
            vidas = vidas - contadorVidas;
            textoVidas.text = "X" + vidas;
        }
        if (vidas<=0)
        {
            Destroy(gameObject);
    }
    }
}
