using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zenitsu : MonoBehaviour
{
    float h;
    int contador;
    [SerializeField] TextMeshProUGUI textoContador;
    [HideInInspector] public bool movimiento;
    SpriteRenderer sR;
    [HideInInspector] public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.06662354f, -4, 0);
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

        textoContador.text = "X " + contador;

        float ClampedX = Mathf.Clamp(transform.position.x, -6.5f, 6.5f);
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
        anim.SetBool("Corriendo", true);
        transform.Translate(new Vector3(h, 0, 0) * 10 * Time.deltaTime);
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

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            h = h * 2;
            anim.SetTrigger("Sprint");
            h = h / 2;
        }

    }
}
