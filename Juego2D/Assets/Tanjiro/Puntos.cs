using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntos : MonoBehaviour
{
    GameObject Puntuacion;
    GameObject narutoKun;
    naruto playerScr;
    int counter = 10;
    TextMeshProUGUI ptosCanvas;
    // Start is called before the first frame update
    void Start()
    {
        Puntuacion = GameObject.FindGameObjectWithTag("ptos");
        narutoKun = GameObject.FindGameObjectWithTag("Player");
        playerScr = narutoKun.GetComponent<naruto>();
        ptosCanvas = Puntuacion.GetComponent<TextMeshProUGUI>();
        ptosCanvas.text = "X" + playerScr.puntos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            playerScr.puntos = playerScr.puntos + counter;
            ptosCanvas.text = "X" + playerScr.puntos;
        }
    }

}
