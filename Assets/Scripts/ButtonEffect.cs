using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] private float offset = 1f;

    private Vector3 initialRotationEuler;

    private void Start()
    {
        initialRotationEuler = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        Vector3 newRotationEuler = initialRotationEuler + new Vector3(0f, 0f, Random.Range(-offset, offset));
        transform.rotation = Quaternion.Euler(newRotationEuler);
    }
}
