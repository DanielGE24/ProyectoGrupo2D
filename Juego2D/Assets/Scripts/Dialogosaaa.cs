using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Dialogosaaa : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string[] textos;
    [SerializeField] string[] nombres;
    [SerializeField] Sprite[] spritesPersonajes;
    
    [SerializeField] Image personajeSR1;
    [SerializeField] Image personajeSR2;
    int contadorFrases = -1;
    int contadorSprites1;
    int contadorSprites2;
    int contadorNombres1;
    int contadorNombres2;
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
    }

    // Update is called once per frame
    void Update()
    {
        textoNombre1.text = nombres[contadorNombres1];
        textoNombre2.text = nombres[contadorNombres2];
        personajeSR1.sprite = spritesPersonajes[contadorSprites1];
        personajeSR2.sprite = spritesPersonajes[contadorSprites2];

        

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hablando==false)
            {
                Hablar();
            }

            else
            {
                Autocompletar();

            }
        }

        if (contadorFrases == 0 ) //Inicio
        {
            
            contadorSprites1 = 31;
            contadorSprites2 = 31;
            
        }

        if (contadorFrases == 1)
        {
            marcoNombre1.SetActive(true);
            contadorSprites1 = 30;
            
            
        }

        if (contadorFrases == 2)
        {
            marcoNombre2.SetActive(true);
            contadorSprites2 = 12;
            contadorNombres2 = 2;
        }

        if (contadorFrases == 3) //Empieza minijuego Inosuke
        {
            SceneManager.LoadScene(2);
        }

        if (contadorFrases == 4)
        {
            contadorSprites1 = 1;
            contadorNombres1 = 1;
        }

        if (contadorFrases == 5)
        {
            contadorSprites1 = 2;
            contadorNombres1 = 2;
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
