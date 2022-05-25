using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_nube : MonoBehaviour
{

   Vector3 posDestino;
    [SerializeField] GameObject ataque2Prefab;
    [SerializeField] GameObject spawner;
   bool enEjecucion = false;

    // Start is called before the first frame update
    void Start()
    {
     posDestino = new Vector3 (Random.Range(0f, 2.6f), Random.Range(-0.9f,1.05f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posDestino, 5 * Time.deltaTime);
        if (transform.position == posDestino)
        {
            if (enEjecucion == false)
            {
             StartCoroutine(DisparosRanas());
            }
        }
    }


IEnumerator DisparosRanas()
{
    enEjecucion = true;
    for (int i = 0; i < 4; i++)
    {
            Instantiate(ataque2Prefab, spawner.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(4f);

    }
        posDestino = new Vector3(Random.Range(0f, 2.6f), Random.Range(-0.9f, 1.05f), 0);
        enEjecucion = false;


}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ataque1"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ataque2"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

