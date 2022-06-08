using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SistemaVideos : MonoBehaviour
{
    [SerializeField] VideoClip[] videosCinem;
    [SerializeField] GameObject[] videosCinemGO;
    [SerializeField] GameObject HUDGeneral;
    [SerializeField] GameObject FadeOutGO;
    [SerializeField] GameObject FadeInGO;
    [SerializeField] Animator animFadeOut;
    [SerializeField] Animator animFadeIn;
    // Start is called before the first frame update
    void Start()
    {
        animFadeIn.SetTrigger("animFi");


        StartCoroutine(DesactivarVideo(10, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator DesactivarVideo(int tiempoVideo, int numeroVideo)
    {
        
        yield return new WaitForSeconds(tiempoVideo); //Espera a que termine el video
        
        FadeInGO.gameObject.SetActive(false);
        videosCinemGO[numeroVideo].gameObject.SetActive(false); //Desactiva el video
        FadeOutGO.gameObject.SetActive(true); 
        animFadeOut.SetTrigger("AnimFO"); //De blanco a negro
        yield return new WaitForSeconds(1);


        FadeOutGO.gameObject.SetActive(false);
        FadeInGO.gameObject.SetActive(true);
        


        HUDGeneral.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);

    }
}
