using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class naruto : MonoBehaviour
{

    Animator anim;
    AnimatorStateInfo estadoActual;

    float coolDown = 1;
    Rigidbody2D rb;
    public int puntos = 0;
    float ultimoDisparo;
    [SerializeField] GameObject AtaquePrefab;
    [SerializeField] GameObject posicionAtaque;
    [SerializeField] GameObject boton;
    PolygonCollider2D pc;
    [SerializeField] GameObject Muerte;
    BoxCollider2D bc;
    bool movimiento;
    [SerializeField] TextMeshProUGUI textoCuentaAtras;
    [SerializeField] GameObject CuentaAtras;
    float cuenta = 5;
    bool cuentaInicio;
    Vidas vidasScr;

    // Start is called before the first frame update
    void Start()
    {
        vidasScr = GetComponent<Vidas>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
        movimiento = false;
        StartCoroutine(EsperaMovimiento());
    }

    // Update is called once per frame
    void Update()
    {
        if (vidasScr.vidas==0)
        {
            movimiento = false;
            SceneManager.LoadScene(8);

        }
        estadoActual = anim.GetCurrentAnimatorStateInfo(0);
        if (movimiento == true)
        {
            Movimiento();
        }

        if (cuentaInicio == true)
        {
            cuenta -= 1 * Time.deltaTime;
            textoCuentaAtras.text = "" + Mathf.Round(cuenta);
        }
    }


    public void Movimiento()
    {
        
        coolDown -= 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) && coolDown <= 0)
        {
            anim.SetTrigger("Dash");
            coolDown = 1;
            pc.enabled = false;
            rb.isKinematic = true;


        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            pc.enabled = true;
            rb.isKinematic = false;
        }


        if (Input.GetKeyDown(KeyCode.W) && coolDown <= 0)
        {
            Debug.Log("Salto");
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            coolDown = 0.65f;

        }


        ultimoDisparo += 1 * Time.deltaTime;

        if (Input.GetMouseButton(0) && ultimoDisparo >= 0.3f && !estadoActual.IsName("Jump"))
        {
            anim.SetTrigger("Attack");

            Instantiate(AtaquePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.1f, 0), Quaternion.identity);


            ultimoDisparo = 0;
        }
    }

    IEnumerator EsperaMovimiento()
    {
        cuentaInicio = true;
        yield return new WaitForSeconds(5);
        CuentaAtras.SetActive(false);
        anim.SetTrigger("Idle");
        movimiento = true;
    }
}




