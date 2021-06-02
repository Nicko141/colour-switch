using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public AudioMixer MasterAudio;
    public AudioSource jumper;
    public Slider music;

    private void Awake()
    {



    }
    


    public void ChangeVolume(float volume)// allows volume change on canvas
    {
        MasterAudio.SetFloat("Volume", volume);
        MasterAudio.SetFloat("Jump", volume);
        MasterAudio.SetFloat("Death", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Jump", volume);
        PlayerPrefs.SetFloat("Death", volume);
        PlayerPrefs.Save();
    }

    
    
    public void onJump()
    {
        jumper.Play();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        MasterAudio.SetFloat("Volume", PlayerPrefs.GetFloat("Volume"));
        MasterAudio.SetFloat("Jump", PlayerPrefs.GetFloat("Jump"));
        MasterAudio.SetFloat("Death", PlayerPrefs.GetFloat("Death"));
        music.value = PlayerPrefs.GetFloat("Volume");
    }
    public void deadPerson()
    {
        MasterAudio.SetFloat("Volume", -80);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sceneChange()//change from one scene to another
    {
        SceneManager.LoadScene(1);
        
    }
    public void tryAgain()// change from one scene to another... attempted fix for binary saving resulted in two of the same function, wasn't needed but is still used.
    {
        SceneManager.LoadScene(1);
        
    }
   
    public void returntoMenu()// return to the main menu scene
    {
        SceneManager.LoadScene(0);
    }
    public void ExitToDesktop()// quits the application and the editor play mode
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
