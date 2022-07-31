using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public Transform StartPoint;
    [SerializeField] int convayorVerlocity;
    // Start is called before the first frame update
    private void OnCollisionStay(Collision collision)
    {
        Transition(collision.gameObject);
    }

    private void Transition(GameObject Trash)
    {
        if (Trash.TryGetComponent<Rigidbody>(out Rigidbody component))
        {
            component.velocity = gameObject.transform.right * Time.deltaTime * convayorVerlocity;
        }
    }

}
