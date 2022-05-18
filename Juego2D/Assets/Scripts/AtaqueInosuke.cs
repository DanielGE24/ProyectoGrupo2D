using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        poderAtacar = true;
        tiempoMaximo = 5;
        tiempo = Mathf.Round(tiempo * 100f) / 100f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo +=1 * Time.deltaTime;

        //---------------------ATAQUE---------------------//

        txtContadorTiempo.text = "Tiempo: " + Mathf.Round(tiempo);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (poderAtacar == true)
            {
            contadorAtaques++;
            anim.SetTrigger("ataque");

            }
        }

        txtContadorAtaques.text = "Ataques: " + contadorAtaques;


        

        //----------------GANAR O PERDER----------------------/

        if (tiempo>=tiempoMaximo)
        {
                tiempo = tiempoMaximo;
                poderAtacar = false;
            if (contadorAtaques<10)
            {
                hasPerdido.SetActive(true);
                anim.SetBool("derrota", true);
            }

            else
            {
                hasGanado.SetActive(true);
                anim.SetBool("victoria", true);
            }
        }

    }

    
}
