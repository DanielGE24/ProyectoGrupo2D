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
    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= 1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.D) && coolDown <= 0)
        {
            anim.SetTrigger("dash");
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
            Debug.Log("Salto");

            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            //transform.Translate(Vector3.up * 5 * Time.deltaTime);
            //anim.SetTrigger("jump");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("aire"))
        {
            anim.SetTrigger("hurt");
            vidas -= 1;


        }

        if (vidas == 0)
        {
            boton.SetActive(true);
            Destroy(gameObject);
        }
            
    }
}


