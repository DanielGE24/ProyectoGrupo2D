using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour {

    [SerializeField] AudioMixer master;
    [SerializeField] GameObject mainPanel, optionsPanel, minigamesPanel;
    [SerializeField] Dropdown graphicsDd;
    List<string> resList = new List<string>();
    [SerializeField] Dropdown resDropDown;
    Resolution[] screenRes;
    int currentResIndex;
    private void Start()
    {
        screenRes = Screen.resolutions;
        for (int i = 0; i < screenRes.Length; i++)
        {
            resList.Add(screenRes[i].width + " x " + screenRes[i].height);

          
            if(screenRes[i].width == Screen.currentResolution.width && screenRes[i].height == Screen.currentResolution.height)
            {
                
                currentResIndex = i;
            }
        }
        resDropDown.ClearOptions();
        resDropDown.AddOptions(resList);

       
        graphicsDd.value = QualitySettings.GetQualityLevel();
        graphicsDd.RefreshShownValue();

        resDropDown.value = currentResIndex;
        resDropDown.RefreshShownValue();
    }

    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }


    public void Minigames()
    {
        mainPanel.SetActive(false);
        minigamesPanel.SetActive(true);
    }

    public void ExitGame()
    {
       
        Application.Quit();
    }

    public void BackOptions()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void BackMinigames()
    {
        mainPanel.SetActive(true);
        minigamesPanel.SetActive(false);
    }



    public void ControlMasterVolume(float volume)
    {
        master.SetFloat("masterVolume", volume);
    }
    public void ControlMusicVolume(float volume)
    {
        master.SetFloat("musicVolume", volume);
    }
    public void ControlSfxVolume(float volume)
    {
        master.SetFloat("sfxVolume", volume);
    }

    

    
    public void SetQuality(int index)
    {
        
        QualitySettings.SetQualityLevel(index);
        graphicsDd.value = index;
    }
    public void SetResolution(int index)
    {
        Screen.SetResolution(screenRes[index].width, screenRes[index].height, Screen.fullScreen);
    }

    public void FullScreen(bool screen)
    {
        Screen.fullScreen = screen;
    }
    public void Tanjiro()
    {
        SceneManager.LoadScene(9);
    }  
    public void Zenitsu()
    {
        SceneManager.LoadScene(5);
    } 
    public void Inosuke()
    {
        SceneManager.LoadScene(2);
    }
    
}
