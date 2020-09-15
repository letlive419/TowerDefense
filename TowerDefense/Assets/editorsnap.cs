using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class editorsnap : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;

    TextMesh textMesh;
    // Update is called once per frame
    void Update()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        

        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);

        string labelCube = snapPos.x / gridSize + "," + snapPos.z / gridSize;

        textMesh.text = labelCube;

        gameObject.name = labelCube;


    }
}
