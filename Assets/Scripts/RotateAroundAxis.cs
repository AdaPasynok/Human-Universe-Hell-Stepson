using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundAxis : MonoBehaviour
{
    protected enum Axis
    {
        x,
        y,
        z
    }

    [SerializeField] protected Axis axis;
    [SerializeField] protected float speed = 5f;

    protected Vector3 axisToRotateAround;

    protected void Start()
    {
        switch (axis)
        {
            case Axis.x:
                axisToRotateAround = transform.right;
                break;
            case Axis.y:
                axisToRotateAround = transform.up;
                break;
            case Axis.z:
                axisToRotateAround = transform.forward;
                break;
        }
    }

    protected void Update()
    {
        transform.Rotate(axisToRotateAround, Time.deltaTime * speed);
    }
}
