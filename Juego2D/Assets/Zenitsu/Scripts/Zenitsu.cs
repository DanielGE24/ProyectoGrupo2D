using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zenitsu : MonoBehaviour
{
    float h;
    [HideInInspector] public int contador = 0;
    [HideInInspector] public bool movimiento;
    SpriteRenderer sR;
    [HideInInspector] public Animator anim;
    int velocidad = 10;
    float cooldown = 1;

    // Start is called before the first frame update
    void Start()
    {
        h = 1;
        movimiento = true;
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movimiento == true)
        {
            Movimiento();
        }

        float ClampedX = Mathf.Clamp(transform.position.x, -5.9f, 5.9f);
        transform.position = new Vector3(ClampedX, -4, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rehen"))
        {
            Destroy(collision.gameObject);
            contador++;           
        }
    }
    public void Movimiento()
    {
        cooldown -= 1 * Time.deltaTime;
        anim.SetBool("Corriendo", true);
        transform.Translate(new Vector3(h, 0, 0) * velocidad * Time.deltaTime);
        if (h == 1)
        {
            if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                h = h * -1;
                sR.flipX = true;
            }
        }

        if (h == -1)
        {

            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                h = h * -1;
                sR.flipX = false;
            }
        }

      
        if ( (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && cooldown <=0)
        {
            velocidad = 15;
            anim.SetTrigger("Sprint");
            cooldown = 0.6f;
        }
       
        if(cooldown <= 0)
        {
            velocidad = 10;
        }


    }
}
