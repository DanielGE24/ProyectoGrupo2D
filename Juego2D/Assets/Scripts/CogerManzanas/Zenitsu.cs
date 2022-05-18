using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zenitsu : MonoBehaviour
{
    float h;
    
    // Start is called before the first frame update
    void Start()
    {
        h = 1;   
    }

    // Update is called once per frame
    void Update()
    {
        float ClampedX = Mathf.Clamp(transform.position.x, -6.5f, 6.5f);
        transform.position = new Vector3(ClampedX, -4, 0);

        transform.Translate(new Vector3(h, 0, 0)*10*Time.deltaTime);
        if (h ==1)
        {
            if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                h = h * -1;
            }
        }

        if (h == -1)
        {
            if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                h = h * -1;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rehen"))
        {
            Destroy(collision.gameObject);
        }
    }

}
