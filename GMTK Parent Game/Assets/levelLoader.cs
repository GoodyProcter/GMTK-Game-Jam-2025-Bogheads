using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public 

    



    // Update is called once per frame
    void Update()
    {
        
    }

    public void newDayCutscene()
    {
        SceneManager.LoadScene(0);
    }

    public void goToLevel()
    {

        SceneManager.LoadScene(1);
        
    }

    public void callEnding()
    {
        //decide which ending to go to here and call it
    }

    public void quit()
    {
        Application.Quit();
    }
    

}
