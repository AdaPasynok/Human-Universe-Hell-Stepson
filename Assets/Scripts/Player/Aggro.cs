using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro : MonoBehaviour
{
    [Range(1f, 50f)]
    [SerializeField] private float radius = 10f;
    [SerializeField] private LayerMask enemyMask;

    private void FixedUpdate()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, radius, enemyMask);

        foreach (Collider enemy in enemies)
        {
            enemy.GetComponent<Enemy>().TryToTargetPlayer(transform.position);
        }
    }

#if UNITY_EDITOR
    // Рисуем аггро радиус в редакторе
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}
