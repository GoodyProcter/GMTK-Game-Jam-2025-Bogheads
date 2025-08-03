using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dogMiniGame : MonoBehaviour
{
    public miniGameChecker miniGameChecker;
    public float countDown;
    public int stages;
    [SerializeField] Sprite[] allFrames;
    public Sprite Frame;
    public GameObject key;
    public GameObject keySpawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false); // will uncomment this later. Interacting with the door with the key will set this to active.
        key.transform.position = keySpawnPoint.transform.position;
        key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = Frame;
        Frame = allFrames[stages];
        Debug.Log(allFrames[stages]);
        //Debug.Log(stages);

        if (stages > 0)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }

            if (countDown == 0)
            {
                stages -= 1;
                countDown = 0.2f;
            }

            if (countDown < 0)
            {
                countDown = 0;
            }
        }

        if (stages < 6)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                stages += 1;
                countDown += 0.2f;
            }

            key.transform.position = keySpawnPoint.transform.position;
            key.SetActive(false);
        }

        if (stages == 6)
        {
            if(countDown < 1f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    countDown += 0.3f;
                }
            }

            key.SetActive(true);
            
        }

        if (stages > 6)
        {
            stages = 6;
        }
    }

    public void startDogMiniGame()
    {
        miniGameChecker.miniGameActive = true;
    }
}

