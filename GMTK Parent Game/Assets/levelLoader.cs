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
        StartCoroutine("LoadCutscene");
    }

    public void goToLevel()
    {
        
        StartCoroutine("LoadLevel");
        
    }

    public void callEnding()
    {
        //decide which ending to go to here and call it
    }

    public void quit()
    {
        Application.Quit();
    }
    

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);

    }

    IEnumerator loadCutscene()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(0);

    }
}
