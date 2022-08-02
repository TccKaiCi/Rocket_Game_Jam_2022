using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Controller : MonoBehaviour
{
    private const float MAXRAYCASTDISTANCE = 1000f;
    public Camera camera;
    public LayerMask interactLayer;
    public float maxUseDistance;
    public LayerMask moveAblePlayer;
    Transform target;
    Transform destination;
    Stack<Vector3> Proceed = new Stack<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChooseHandle();

        }

    }

    private void ChooseHandle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(mousePos, Camera.main.transform.forward * MAXRAYCASTDISTANCE, Color.red);
        if (Physics.Raycast(mousePos, Camera.main.transform.forward * MAXRAYCASTDISTANCE, out RaycastHit hit))
        {
            Debug.Log(hit.collider.name);
            GameObject cursorObj = hit.collider.gameObject;
            MoveTrashToBin(cursorObj);
        }
    }

    private void MoveTrashToBin(GameObject cursorObj)
    {
       
        if (cursorObj.CompareTag("Trash"))
        {
            target = cursorObj.transform;
        }
        else
        {
            if(target!=null&&cursorObj.CompareTag("Bin"))
            destination = cursorObj.transform;
        }
        if (target!= null && destination != null)
        {
            MoveTrash();
            ResetChoose();
        }
    }

    private void MoveTrash()
    {
        Vector3 des = destination.transform.position;
        Transform begin = target;
        begin.DOMove(des, 1);
    }

    private void ResetChoose()
    {
        destination = null;
        target = null;
    }
}
