using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naruto : MonoBehaviour
{

    Animator anim;
    SpriteRenderer sR;
    float coolDown = 1;
    Rigidbody2D rb;
    public int puntos = 0;
    float ultimoDisparo;
    [SerializeField] GameObject AtaquePrefab;
    [SerializeField] GameObject posicionAtaque;
    [SerializeField] GameObject boton;
    int vidas = 5;
    PolygonCollider2D pc;
    [SerializeField] GameObject Muerte;
    BoxCollider2D bc;
    bool movimiento;
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
        movimiento = false;
        StartCoroutine(EsperaMovimiento());
    }

    // Update is called once per frame
    void Update()
    {
        if (movimiento == true)
        {
            Movimiento();
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("aire"))
        {
            anim.SetTrigger("Hurt");
            StartCoroutine (CambiarColor());
            vidas -= 1;


        }

        if (vidas == 0)
        {
            boton.SetActive(true);
            Destroy(gameObject);
        }
            
    }
    IEnumerator CambiarColor()
    {
        sR.color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(0.2f);
        sR.color = new Color32(255, 255, 255, 255);
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



        if (Input.GetKeyDown(KeyCode.A) && coolDown <= 0)
        {
            anim.SetTrigger("guard");
            coolDown = 1;

        }



        if (Input.GetKeyDown(KeyCode.W) && coolDown <= 0)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            coolDown = 0.65f;

        }


        ultimoDisparo += 1 * Time.deltaTime;

        if (Input.GetMouseButton(0) && ultimoDisparo >= 0.3f)
        {
            anim.SetTrigger("Attack");

            Instantiate(AtaquePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.1f, 0), Quaternion.identity);


            ultimoDisparo = 0;
        }
    }

    IEnumerator EsperaMovimiento()
    {       
        yield return new WaitForSeconds(3);
        anim.SetTrigger("Idle");
        movimiento = true;
    }
}




