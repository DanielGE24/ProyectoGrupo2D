using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gM;
    public AudioClip[] clips;
    //Patrón singleton.
    private void Awake()
    {
        if(gM == null)
        {
            gM = this;
        }
        else if(gM !=this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    
}
