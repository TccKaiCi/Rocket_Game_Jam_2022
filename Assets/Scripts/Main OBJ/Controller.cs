using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Controller : MonoBehaviour
{
    public Camera camera;
    public float maxUseDistance;
    public LayerMask moveAblePlayer;
    Transform target;
    Transform destination;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawRay(mousePos, Camera.main.transform.forward * 1000, Color.red);
            if (Physics.Raycast(mousePos, Camera.main.transform.forward * 1000f, out RaycastHit hit))
            {
                Debug.Log(hit.collider.name);
                GameObject cursorObj = hit.collider.gameObject;
                MoveTrashToBin(cursorObj);
            }
           
       
        }

        /* Camera.main.ScreenToWorldPoint(Input.mousePosition);*/
    }

    private void MoveTrashToBin(GameObject cursorObj)
    {
       
        if (cursorObj.CompareTag("Trash"))
        {
            target = cursorObj.transform;
            Debug.Log("target " + target.name);

        }
        else
        {
            destination = cursorObj.transform;
            Debug.Log("destination " + destination.name);
        }
        if (cursorObj != null && destination != null)
        {
            Debug.Log(target.name + " " + destination.name);
            Debug.Log(destination.transform.position);
            target.transform.DOMove(destination.transform.position, 3f);
        }
    }

 }
