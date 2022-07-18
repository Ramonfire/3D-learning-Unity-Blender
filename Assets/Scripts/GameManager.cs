using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int Checkpoint=0;
    public int deaths=0; 
    public int sceneId;
    public static GameManager instance;
    public Transform[] checkpoints;


    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }



    public void UpdateCheckPoint(int i)
    {
        Checkpoint = i;
    }

    public void UpdateDeathCount()
    {
        deaths++;
    }


    public void loadScene()
    {

        sceneId = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(sceneId);
    }

}
