using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Dialogos6 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string[] textos;
    [SerializeField] string[] nombres;
    [SerializeField] Sprite[] spritesPersonajes;
    [SerializeField] Sprite[] fondos;


    [SerializeField] Image personajeSR1;
    [SerializeField] Image personajeSR2;
    [SerializeField] Image fondoEscena;
    int contadorFrases = -1;
    int contadorSprites1;
    int contadorSprites2;
    int contadorNombres1;
    int contadorNombres2;
    int contadorFondos;
    [SerializeField] GameObject marcoTexto;



    [SerializeField] TextMeshProUGUI texto;

    [SerializeField] GameObject marcoNombre1;
    [SerializeField] GameObject marcoNombre2;
    string nombre;
    [SerializeField] TextMeshProUGUI textoNombre1;
    [SerializeField] TextMeshProUGUI textoNombre2;

    bool hablando;
    void Start()
    {
        contadorFondos = 3;
        contadorSprites1 = 31;
        contadorSprites2 = 31;

    }

    // Update is called once per frame
    void Update()
    {
        textoNombre1.text = nombres[contadorNombres1];
        textoNombre2.text = nombres[contadorNombres2];
        personajeSR1.sprite = spritesPersonajes[contadorSprites1];
        personajeSR2.sprite = spritesPersonajes[contadorSprites2];
        fondoEscena.sprite = fondos[contadorFondos];



        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hablando == false)
            {
                Hablar();
            }

            else
            {
                Autocompletar();

            }
        }

        if (contadorFrases == 0) //Inicio
        {
            marcoNombre1.SetActive(true);
            contadorFondos = 3;
            contadorSprites1 = 0;
            contadorNombres1 = 0;




        }

        if (contadorFrases == 1)
        {
            marcoNombre2.SetActive(true);
            contadorSprites2 = 17;
            contadorNombres2 = 3;


        }

        if (contadorFrases == 2)
        {
            contadorSprites1 = 0;
            contadorNombres1 = 0;

        }

        if (contadorFrases == 3)
        {

            marcoNombre2.SetActive(true);
            contadorNombres2 = 1;
            contadorSprites2 = 5;
        }

        if (contadorFrases == 4)
        {
            contadorNombres2 = 2;
            contadorSprites2 = 11;

        }

        if (contadorFrases == 5)
        {
            marcoNombre1.SetActive(false);
            marcoNombre2.SetActive(false);
            contadorSprites2 = 31;
        }

        if (contadorFrases == 6)
        {
            contadorNombres2 = 2;
            contadorSprites2 = 11;
        }

        if (contadorFrases == 7)
        {
            contadorNombres2 = 1;
            contadorSprites2 = 5;
        }

        if (contadorFrases == 8)
        {

        }

        if (contadorFrases == 9)
        {


        }


        if (contadorFrases == 10)
        {
            contadorNombres2 = 2;
            contadorSprites2 = 11;
        }

        if (contadorFrases == 11)
        {
            marcoNombre1.SetActive(true);
            contadorSprites1 = 4;
            marcoNombre2.SetActive(false);
            contadorSprites2 = 31;
            contadorNombres1 = 0;
        }

        if (contadorFrases == 12)
        {

        }

        if (contadorFrases == 13)
        {
            marcoNombre2.SetActive(true);
            contadorSprites2 = 9;
            contadorNombres2 = 1;
        }

        if (contadorFrases == 14)
        {
            contadorSprites2 = 11;
            contadorNombres2 = 2;
        }

        if (contadorFrases == 15)
        {
            contadorSprites2 = 17;
            contadorNombres2 = 3;
        }

        if (contadorFrases == 16)
        {
            marcoNombre2.SetActive(false);
            marcoNombre1.SetActive(false);
            contadorSprites1 = 31;
            contadorSprites2 = 31;

        }

        if (contadorFrases == 17)
        {
            marcoNombre2.SetActive(true);
            contadorSprites2 = 29;
            contadorNombres2 = 5;

        }
        if (contadorFrases == 18)
        {
            marcoNombre1.SetActive(true);
            contadorSprites1 = 1;
            contadorSprites2 = 28;
        }

        if (contadorFrases == 19)
        {
            //Iniciar juego del gonpachiro contra el malo
        }









    }


    public void Hablar()
    {
        marcoTexto.SetActive(true);

        //marcoNombre2.SetActive(true);



        SiguienteFrase();


    }

    public void Autocompletar()
    {
        StopAllCoroutines();
        texto.text = textos[contadorFrases];
        hablando = false;

    }


    IEnumerator EscribirFrase()
    {
        hablando = true;

        texto.text = "";

        char[] caracs = textos[contadorFrases].ToCharArray();

        for (int i = 0; i < caracs.Length; i++)
        {
            texto.text += caracs[i];
            yield return new WaitForSeconds(0.1f);
        }
        hablando = false;

    }


    void SiguienteFrase()
    {
        texto.text = "";
        contadorFrases++;
        if (contadorFrases == textos.Length)
        {
            //Desactivo el marco y reseteo el contador de frases.
            marcoTexto.SetActive(false);


            marcoNombre1.SetActive(false);
            marcoNombre2.SetActive(false);
            contadorFrases = -1;

        }

        else
        {
            //Si no, escribo la frase correspondiente.
            StartCoroutine(EscribirFrase());
        }

    }
}
