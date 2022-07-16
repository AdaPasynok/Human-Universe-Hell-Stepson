using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffectLine : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField] private float intensity = 5f;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.ForceMeshUpdate();
        Mesh mesh = text.mesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += new Vector3(Mathf.Sin((Time.time + i) * intensity), Mathf.Sin((Time.time + i) * intensity), 0f);
        }

        mesh.vertices = vertices;
        text.canvasRenderer.SetMesh(mesh);
    }
}
