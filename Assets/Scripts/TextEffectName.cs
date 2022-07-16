using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEffectName : MonoBehaviour
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

        for (int i = 0; i < text.textInfo.characterCount - 1; i++)
        {
            TMP_CharacterInfo character = text.textInfo.characterInfo[i];

            int index = character.vertexIndex;

            Vector3 offset = new Vector3(Mathf.Sin(Time.time + i) * intensity, Mathf.Cos(Time.time + i) * intensity, 0f);
            vertices[index + 2] += offset;
            vertices[index + 3] += offset;
            vertices[index + 4] += offset;
            vertices[index + 5] += offset;
        }

        mesh.vertices = vertices;
        text.canvasRenderer.SetMesh(mesh);
    }
}
