using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject RehenPrefab;
    [HideInInspector] public float tiempo;
    [SerializeField] TextMeshProUGUI textoTimer;
    Zenitsu player;
    bool sumarTimer;
    Destructor muertes;
    Zenitsu contador;
    [SerializeField] TextMeshProUGUI textoContador;
    [SerializeField] GameObject derrota;
    [SerializeField] GameObject victoria;
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
    public IEnumerator SpawnRehenes()
    {
        yield return new WaitForSeconds(5);
        sumarTimer = true;       
        player.movimiento = true;
        while (tiempo <= 30)
        {
            Instantiate(RehenPrefab, new Vector3(Random.Range(-6, 7), 5, 0), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        while (tiempo > 30 && tiempo <= 60)
        {
            Instantiate(RehenPrefab, new Vector3(Random.Range(-6, 7), 5, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
