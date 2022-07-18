using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int Checkpoint=0;
    public int deaths=0; 
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

 


}
