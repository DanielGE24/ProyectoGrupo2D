using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] rehenes;
    [HideInInspector] public float tiempo;
    [SerializeField] TextMeshProUGUI textoTimer;
    Zenitsu player;
    bool sumarTimer;
    Destructor muertes;
    Zenitsu contador;
    float cuenta = 5;
    bool cuentaInicio;
    [SerializeField] TextMeshProUGUI textoContador;
    [SerializeField] GameObject derrota;
    [SerializeField] GameObject victoria;
    [SerializeField] TextMeshProUGUI textoCuentaAtras;
    [SerializeField] GameObject cuentaAtras;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRehenes());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Zenitsu>();
        player.movimiento = false;
        muertes = GameObject.FindGameObjectWithTag("Destructor").GetComponent<Destructor>();
        contador = GameObject.FindGameObjectWithTag("Player").GetComponent<Zenitsu>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cuentaInicio == true)
        {
            cuenta -= 1 * Time.deltaTime;
            textoCuentaAtras.text = "" + Mathf.Round(cuenta);
        }
        if (sumarTimer == true)
        {
            tiempo += 1 * Time.deltaTime;
            textoTimer.text = "Time: " + Mathf.Round(tiempo);
            textoContador.text = "X " + contador.contador;
        }

        if (tiempo >= 60 && muertes.contadorMuertes <= 5)
        {
            StopAllCoroutines();
            player.movimiento = false;
            sumarTimer = false;
            player.anim.SetTrigger("Victoria");
            victoria.SetActive(true);
        }
        else if (muertes.contadorMuertes >= 5)
        {
            StopAllCoroutines();
            player.movimiento = false;
            sumarTimer = false;
            player.anim.SetTrigger("Derrota");
            derrota.SetActive(true);
        }

    }
    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }

    public IEnumerator SpawnRehenes()
    {
        cuentaInicio = true;
        yield return new WaitForSeconds(5);
        cuentaAtras.SetActive(false);
        sumarTimer = true;
        player.movimiento = true;
        while (tiempo <= 30)
        {
            Instantiate(rehenes[Random.Range(0, rehenes.Length)], new Vector3(Random.Range(-6, 7), 5, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        while (tiempo > 30 && tiempo <= 60)
        {
            Instantiate(rehenes[Random.Range(0, rehenes.Length)], new Vector3(Random.Range(-6, 7), 5, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

    }
    
}
