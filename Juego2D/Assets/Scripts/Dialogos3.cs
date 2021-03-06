using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Dialogos3 : MonoBehaviour
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

        contadorSprites1 = 31;
        contadorSprites2 = 31;
        contadorFondos = 0;
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
            contadorFondos = 0;
            contadorSprites1 = 3;
            marcoNombre1.SetActive(true);
            contadorNombres1 = 0;
            contadorSprites2 = 31;

        }

        if (contadorFrases == 1)
        {
            marcoNombre2.SetActive(true);
            contadorSprites2 = 19;
            contadorNombres2 = 3;


        }

        if (contadorFrases == 2)
        {
            contadorSprites1 = 2;

        }

        if (contadorFrases == 3) //Empieza minijuego Inosuke
        {
            
            contadorSprites2 = 18;
        }

        if (contadorFrases == 4)
        {
            contadorSprites2 = 19;
        }

        if (contadorFrases == 5)
        {
            contadorSprites2 = 18;
        }

        if (contadorFrases == 6)
        {
            contadorSprites1 = 3;



        }

        if (contadorFrases == 7)
        {
            contadorSprites2 = 14;
            contadorNombres2 = 2;
        }

        if (contadorFrases == 8)
        {
            contadorSprites2 = 7;
            contadorNombres2 = 1;
        }

        if (contadorFrases == 9)
        {
            contadorSprites1 = 30;
        }


        if (contadorFrases == 10)
        {
            contadorSprites2 = 19;
            contadorNombres2 = 3;
        }

        if (contadorFrases == 11)
        {
            contadorSprites2 = 20;
        }

        if (contadorFrases == 12)
        {

        }

        if (contadorFrases == 13)
        {

        }

        if (contadorFrases == 14)
        {

        }

        if (contadorFrases == 15)
        {

        }

        if (contadorFrases == 16)
        {

        }

        if (contadorFrases == 17)
        {
        
            marcoNombre1.SetActive(false);
            marcoNombre2.SetActive(false);

            contadorSprites1 = 31;
            contadorSprites2 = 31;
        }
        if (contadorFrases == 18)
        {
            marcoTexto.SetActive(false);
        }

        if (contadorFrases ==19)
        {
            
            marcoTexto.SetActive(true);
            contadorFondos = 2;
        }

        if (contadorFrases == 20)
        {

        }

        if (contadorFrases == 21)
        {

        }

        if (contadorFrases == 22)
        {

        }

        if (contadorFrases == 23)
        {
            contadorFondos = 1;
            marcoNombre2.SetActive(true);
            contadorSprites2 = 11;
            contadorNombres2 = 2;
        }

        if (contadorFrases == 24)
        {
            contadorSprites1 = 23;
            
        }

        if (contadorFrases == 25)
        {
            marcoNombre1.SetActive(true);
            contadorNombres1 = 4;
        }

        if (contadorFrases == 26)
        {
            contadorSprites2 = 16;
            contadorNombres2 = 2;
        }

        if (contadorFrases == 27)
        {
            contadorSprites2 = 15;
        }

        if (contadorFrases == 28)
        {

        }

        if (contadorFrases == 30)
        {
            SceneManager.LoadScene(5);
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
