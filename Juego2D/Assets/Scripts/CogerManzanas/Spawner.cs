using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject RehenPrefab;
    float tiempo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRehenes());
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += 1 * Time.deltaTime;
        if (tiempo <= 60)
        {
            StopAllCoroutines();
        }
    }
    IEnumerator SpawnRehenes()
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
