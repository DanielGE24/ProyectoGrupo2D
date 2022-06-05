using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AtaqueInosuke : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI txtContadorAtaques;
    [SerializeField] TextMeshProUGUI txtContadorTiempo;
    [SerializeField] GameObject hasPerdido;
    [SerializeField] GameObject hasGanado;
    bool poderAtacar;
    public int contadorAtaques;
    public float tiempo;
    float tiempoMaximo;
    Animator anim;
    
    void Start()
    {
        tiempoMaximo = 10;
        tiempo = Mathf.Round(tiempo * 100f) / 100f;
        anim = GetComponent<Animator>();
        StartCoroutine(Espera());

    }

    // Update is called once per frame
    void Update()
    {
        tiempo += 1 * Time.deltaTime;

        //---------------------ATAQUE---------------------//


        if (poderAtacar == true)
        {
            Atacar();
        }



        //----------------GANAR O PERDER----------------------/

        if (tiempo >= tiempoMaximo)
        {
            tiempo = tiempoMaximo;
            poderAtacar = false;
            if (contadorAtaques < 10)
            {
                hasPerdido.SetActive(true);
                anim.SetBool("derrota", true);
            }

            else
            {
                hasGanado.SetActive(true);
                anim.SetBool("victoria", true);
                StartCoroutine(seguirHistoria());
            }
        }

    }
    void Atacar()
    {
     
        txtContadorTiempo.text = "Tiempo: " + Mathf.Round(tiempo);
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                contadorAtaques++;
                anim.SetTrigger("ataque");

            }
            txtContadorAtaques.text = "Ataques: " + contadorAtaques;
        }
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(5);
        poderAtacar = true;
        tiempo = 0;
        anim.SetTrigger("Idle");
    }



    void RetryButton()
    {
        
    }

    IEnumerator seguirHistoria()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(2);
    }
}




