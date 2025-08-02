using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;


    // Update is called once per frame
    void Update()
    {

    }

    public void newDayCutscene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetSceneAt(0).buildIndex)); // this won't work and will need to be changed
    }

    public void goToLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void callEnding()
    {
        //decide which ending to go to here and call it
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }
}
