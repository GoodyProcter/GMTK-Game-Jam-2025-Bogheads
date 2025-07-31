using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class dayScript : MonoBehaviour
{
    public int dayNum;
    public GameObject dayTextObj;
    static bool spawned = false;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
        dayTextObj = GameObject.Find("Day Text");
        TMP_Text dayTextText = dayTextObj.GetComponent<TMP_Text>();

        DontDestroyOnLoad(this);

        if (spawned)
        {
            Destroy(gameObject);

        }
        else
        {
            spawned = true;
        }

        // Update is called once per frame
        void Update()
        {

            TMP_Text dayTextText = dayTextObj.GetComponent<TMP_Text>();
            dayTextText.text = ("Day Number: " + dayNum.ToString());

            if (Input.GetKey(KeyCode.Space))
            {
                dayNum += 1;
                SceneManager.LoadScene(sceneName: "Tiles Test Scene");
            }
        }
    }
}
