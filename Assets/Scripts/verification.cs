using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class verification : MonoBehaviour
{
   public static int enemyCount;
    public int view;

    private void Update()
    {
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
