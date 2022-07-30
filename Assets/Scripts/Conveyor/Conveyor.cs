using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public  Transform StartPoint;
    [SerializeField] int convayorVerlocity;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        collision.gameObject.GetComponent<Rigidbody>().velocity = gameObject.transform.right* Time.deltaTime * convayorVerlocity;
    }

 
}
