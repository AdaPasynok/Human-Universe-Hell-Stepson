using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // ������ ������, ����� �� ������� � �� �� �������, ��� � �����
    private void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, cameraTransform.rotation.eulerAngles.y, 0f);
    }
}
