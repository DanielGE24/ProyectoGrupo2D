using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rasengan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 2 * Time.deltaTime, Space.World);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemigo"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Muerte"))
        {
            Destroy(gameObject);
        }
    }
}
