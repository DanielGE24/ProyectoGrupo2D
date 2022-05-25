using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_ranita : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ataqueEPrefab;
    [SerializeField] GameObject spawnertaquePrefab;
    float vidas=10;
    Animator anim;
    void Start()
    {
        anim = GetComponent <Animator>();
        StartCoroutine(AtaqueE());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ataque1"))
        {
            vidas -= 1;
            anim.SetTrigger("Danho");
        } 
        if (collision.gameObject.CompareTag("Player"))
        {
            vidas -= 1;
            anim.SetTrigger("Danho");
        }

        if (vidas == 0)
        {
            Destroy(gameObject);
            anim.SetTrigger("Muerte");
            StopAllCoroutines();
        }
    }
    IEnumerator AtaqueE()
    {
        while (true)
        {
            Instantiate(ataqueEPrefab, spawnertaquePrefab.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        } 
        
    }
}
