using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    [HideInInspector] public Vector3 direction = Vector3.forward;

    // На всякий случай деспоним пулю через X секунд после создания
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * direction, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
