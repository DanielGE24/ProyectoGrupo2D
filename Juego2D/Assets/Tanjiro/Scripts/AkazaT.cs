using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkazaT : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject ataqueEPrefab;
    [SerializeField] GameObject spawnertaquePrefab;
    [SerializeField] float vidas;
    Animator anim;
    SpriteRenderer sR;
    GameObject Rengoku;
    Vidas vidasScr;
    Coroutine llamadaAtaque;
    void Start()
    {
        Rengoku = GameObject.FindGameObjectWithTag("Player");
        vidasScr = Rengoku.GetComponent<Vidas>();
        anim = GetComponent<Animator>();
        StartCoroutine(EsperaMovimiento());
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidasScr.vidas == 0)
        {
            StopCoroutine(llamadaAtaque);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ataque1"))
        {
            StartCoroutine(RecibirDanho());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(RecibirDanho());
        }

        if (vidas == 0)
        {

            anim.SetTrigger("Muerte");
            StopAllCoroutines();
        }
    }
    IEnumerator AtaqueE()
    {
        while (true)
        {
            anim.SetTrigger("Attack");
            Instantiate(ataqueEPrefab, spawnertaquePrefab.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            Instantiate(ataqueEPrefab, spawnertaquePrefab.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            Instantiate(ataqueEPrefab, spawnertaquePrefab.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }

    }
    IEnumerator EsperaMovimiento()
    {
        yield return new WaitForSeconds(5);
        anim.SetTrigger("Idle");
        llamadaAtaque = StartCoroutine(AtaqueE());
    }
    IEnumerator RecibirDanho()
    {
        vidas -= 1;
        anim.SetTrigger("Hurt");
        StartCoroutine(CambiarColor());
        yield return new WaitForSeconds(0.1f);
    }
    IEnumerator CambiarColor()
    {
        sR.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(0.2f);
        sR.color = new Color32(255, 255, 255, 255);
    }

}