using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePingPong : RotateAroundAxis
{
    [SerializeField] private float amount = 30f;

    private new void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, 1f);
        float step = Mathf.SmoothStep(-amount, amount, pingPong);

        transform.rotation = Quaternion.Euler(axisToRotateAround * step);
    }
}
