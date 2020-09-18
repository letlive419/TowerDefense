using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]




public class editorsnap : MonoBehaviour
{
   



    WayPoint wayPoint;

    void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
    }
    // Update is called once per frame
    void Update()
    {
        SnapPos();

        LabelPos();

    }

    private void SnapPos()
    {
        int gridSize = wayPoint.GetGridSize();

        transform.position = new Vector3(wayPoint.GetGridPos().x * gridSize, 0f, wayPoint.GetGridPos().y * gridSize);
    }

    private void LabelPos()
    {
        

        TextMesh textMesh = GetComponentInChildren<TextMesh>();

       

        string labelCube = wayPoint.GetGridPos().x + "," + wayPoint.GetGridPos().y;

        textMesh.text = labelCube;

        gameObject.name = labelCube;
    }

    
}
