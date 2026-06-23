using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateScenario : MonoBehaviour
{
    public static GenerateScenario instance;

    public GameObject background;
    public GameObject pipes;

    public float positionToSpawnBackground = 0;

    public static bool isGameStarted = false;

    public List<GameObject> backgroundList = new List<GameObject>();
    public List<GameObject> pipeList = new List<GameObject>();

    // Use this for initialization
    void Awake ()
    {
        instance = this;
	}
	
    // Update is called once per frame
	void Update ()
    {
        //if camera is close to the end of the background scenario, add 10 more background scenarios to the game
        if(transform.position.x >= (positionToSpawnBackground - 4f))
        {
            int backgroundLoopNumber;

            if(!isGameStarted)
                backgroundLoopNumber = 1;
            else
                backgroundLoopNumber = 10;

            float positionToSpawnBackgroundBeforeLoopStarts = positionToSpawnBackground;
            for (int i = 0; i < backgroundLoopNumber; i++)
            {
                if (background != null)
                {
                    Vector3 positionToSpawnV3 = new Vector3(positionToSpawnBackground, 0);
                    GameObject scenario = Instantiate(background, positionToSpawnV3, Quaternion.identity);
                    backgroundList.Add(scenario);
                    positionToSpawnBackground += 4.5f;
                }
            }
            //if game is started, start spawning pipes at random positions
            if (isGameStarted && pipes != null)
            {
                float positionToInstantiatePipes = 0;
                for (int i = 0; i < 22; i++)
                {
                    float yPos = Random.Range(-1.34f, 1.03f);
                    GameObject pipe = Instantiate(pipes, new Vector3((positionToInstantiatePipes + positionToSpawnBackgroundBeforeLoopStarts), yPos), Quaternion.identity);
                    pipeList.Add(pipe);
                    positionToInstantiatePipes += 2;
                }
            }
            CleanUsedBackgrounds();
        }

    }

    void CleanUsedBackgrounds()
    {
        int numbersRequiredToStartTheCleaningProcess;
        int backgroundsLoopNumber;

        if (!isGameStarted)
        {
            backgroundsLoopNumber = 1;
            numbersRequiredToStartTheCleaningProcess = 3;
        }
        else
        {
            backgroundsLoopNumber = 10;
            numbersRequiredToStartTheCleaningProcess = 13;
        }

        if(backgroundList.Count >= numbersRequiredToStartTheCleaningProcess)
        {
            int backgroundsToRemove = Mathf.Min(backgroundsLoopNumber, backgroundList.Count);
            for (int i = 0; i < backgroundsToRemove; i++)
            {
                if (backgroundList.Count > 0 && backgroundList[0] != null)
                {
                    Destroy(backgroundList[0]);
                    backgroundList.RemoveAt(0);
                }
            }

            if (isGameStarted)
            {
                int pipesToRemove = Mathf.Min(20, pipeList.Count);
                for (int i = 0; i < pipesToRemove; i++)
                {
                    if (pipeList.Count > 0 && pipeList[0] != null)
                    {
                        Destroy(pipeList[0]);
                        pipeList.RemoveAt(0);
                    }
                }
            }
        }
    }

    public void CleanAllBackground()
    {
        int backgroundListCount = backgroundList.Count;
        int pipeListCount = pipeList.Count;

        for (int a = 0; a < backgroundListCount; a++)
        {
            if (backgroundList.Count > 0 && backgroundList[0] != null)
            {
                Destroy(backgroundList[0].gameObject);
                backgroundList.RemoveAt(0);
            }
        }

        for (int b = 0; b < pipeListCount; b++)
        {
            if (pipeList.Count > 0 && pipeList[0] != null)
            {
                Destroy(pipeList[0].gameObject);
                pipeList.RemoveAt(0);
            }
        }

        positionToSpawnBackground = 0;
    }

}
