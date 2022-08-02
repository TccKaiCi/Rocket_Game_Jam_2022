using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Controller : MonoBehaviour
{
    private const float MAXRAYCASTDISTANCE = 1000f;
    private const float TRASHSPEED = 0.3f;
    public Camera camera;
    public LayerMask trashLayer;
    public LayerMask binLayer;
    public Transform target;
    Transform destination;
    Stack<Vector3> Proceed = new Stack<Vector3>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ChooseHandle();

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (target != null && destination != null)
            {
                MoveTrash();
                ResetChoose();
            }
            ResetChoose();
        }

    }

    private void ChooseHandle()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        OnRayBin(ray);
        OnRayTrash(ray);

        if (target != null)
            target.position = new Vector3(mousePos.x, mousePos.y, target.transform.position.z);

    }
    public void OnRayTrash(Ray ray)
    {
        RaycastHit hitTrash;
        if (Physics.Raycast(ray, out hitTrash, 100, trashLayer))
        {
            Debug.Log("Set Targeted " + hitTrash.collider.name);
            target = hitTrash.transform;
        }

    }

    private void OnRayBin(Ray ray)
    {
        RaycastHit hitBin;

        if (Physics.Raycast(ray, out hitBin, 100, binLayer) && target != null)
        {
            Debug.Log("Set Destination " + hitBin.collider.name);
            destination = hitBin.transform;
        }
    }

    private void MoveTrash()
    {
        //this code make trash cant choose when they going to be handler by bin
        target.gameObject.layer = LayerMask.NameToLayer("OnHandlerTrash");
        //set path
        Vector3 des = destination.transform.position;
        Transform begin = target;
        begin.DOMove(des, TRASHSPEED);
    }

    private void ResetChoose()
    {
        destination = null;
        target = null;
    }
}
