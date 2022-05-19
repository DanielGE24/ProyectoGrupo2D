using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject RehenPrefab;
    float tiempo;
    [SerializeField] TextMeshProUGUI textoTimer;
    Zenitsu player;
    Destructor contador;
    bool sumarTimer;
    [SerializeField] TextMeshProUGUI textoVictoria;
    [SerializeField] GameObject imgnVictoria;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Zenitsu>();
        contador = GetComponent<Destructor>();
        sumarTimer = true;
        StartCoroutine(SpawnRehenes());
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += 1 * Time.deltaTime;
        if (sumarTimer == true)
        {
            textoTimer.text = "Time: " + Mathf.Round(tiempo);
        }
       
        if (tiempo >= 60 && contador.contadorMuertes <= 15)
        {
            player.movimiento = false;
            sumarTimer = false;
            imgnVictoria.SetActive(true);
            textoVictoria.text = "Has ganado";
            //StopAllCoroutines();            
        }
        //if (tiempo <= 60 && contador.contadorMuertes >= 5)
        //{
        //    player.movimiento = false;
        //    sumarTimer = false;
        //    //pierdes
        //}

    }
    public IEnumerator SpawnRehenes()
    {
        yield return new WaitForSeconds(5);
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
