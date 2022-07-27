using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ChangeText : MonoBehaviour
{
   public  List<string> texts;
    public Text text;
    public TextMeshProUGUI textTMP;
    public float lastShown;
    public int index=0;

    // Update is called once per frame
    void Update()
    {
        if (text == null)
        {
            if (Time.time - lastShown > 5)
            {
                if (index == texts.Count)
                {
                    Destroy(gameObject);
                }
                else
                {
                    textTMP.text = texts[index];
                    lastShown = Time.time;
                    index++;
                }
            }
        }
        else { 
             if (Time.time - lastShown > 5)
                {
                  if (index == texts.Count)
                   {
                Destroy(gameObject);
                   }
                else { 
                 text.text = texts[index];
                 lastShown = Time.time;
                 index++; 
                 }
        }
        }
    }
}
