using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class verification : MonoBehaviour
{
   public static int enemyCount;
    public int view;
    public Transform spawnPoint;
    public AudioSource ambient;


    protected virtual void Start()
    {
        GameManager.instance.checkpoints[0] = spawnPoint;
        GameManager.instance.GetComponent<AmbientNoisePlayer>().ambient = ambient;
    }
    private void Update()
    {
        GameManager.instance.checkpoints[0] = spawnPoint;
        if (enemyCount == 18)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        view = enemyCount;
    }


    public static void updateEnemyCount()
    {
        enemyCount++;
    }
}
