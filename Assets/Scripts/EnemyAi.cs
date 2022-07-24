using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    public Transform Player;
    public Collider MyHitbox;

    // Start is called before the first frame update
    void Start()
    {
        MyHitbox = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
