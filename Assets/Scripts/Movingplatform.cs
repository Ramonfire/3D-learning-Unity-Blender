using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform : MonoBehaviour
{
    private Vector3 Origin;
    private Vector3 Destination;
    public Vector3 movement;
    public Vector3 moveDelta;
    public bool toOrigin;

    private void Start()
    {
        Origin = transform.position;
        Destination = transform.position + movement;
        toOrigin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toOrigin)
        {
            Vector3 position1 = (Origin - transform.position).normalized;
            UpdateMotor(position1);

        }
        else
        {
            Vector3 position1 = (Destination - transform.position).normalized;
            UpdateMotor(position1);
        }

        if (!toOrigin && (Destination-transform.position==Vector3.zero))
        {
            toOrigin = true;
        }
        if (toOrigin && (Origin - transform.position == Vector3.zero))
        {
            toOrigin = false;
        }

        
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3(input.x, input.y, input.z);


        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        
    }
}
