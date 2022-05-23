using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Personaje1()
    {
        SceneManager.LoadScene(0);
    }
    public void Personaje2()
    {
        SceneManager.LoadScene(1);
    }
    public void Personaje3()
    {
        SceneManager.LoadScene(2);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }

}
