using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sceneChange()
    {
        SceneManager.LoadScene(1);
        
    }
    public void tryAgain()
    {
        SceneManager.LoadScene(1);
        
    }
   
    public void returntoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitToDesktop()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
