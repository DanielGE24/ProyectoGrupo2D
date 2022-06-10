using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vidas : MonoBehaviour
    
{
    [SerializeField] GameObject vidasxd;
    [SerializeField] public int vidas;
    int contadorVidas= 1;
    TextMeshProUGUI textoVidas;
    Animator anim;
    SpriteRenderer sR;
    BoxCollider2D coll;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        textoVidas = vidasxd.GetComponent<TextMeshProUGUI>();
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        textoVidas.text = "X" + vidas;
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <=0)
        {
            vidas = 0;
        }
        if (vidas == 0)
        {
            StopAllCoroutines();
            anim.SetTrigger("Muerte");
            coll.enabled = false;
            rb.isKinematic = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("aire"))
        {
            if (vidas > 0)
            {
                vidas = vidas - contadorVidas;
            }
            textoVidas.text = "X" + vidas;
            anim.SetTrigger("Hurt");
            StartCoroutine(CambiarColor());
        }
    }

  
    IEnumerator CambiarColor()
    {
        sR.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(0.2f);
        sR.color = new Color32(255, 255, 255, 255);
    }
}
