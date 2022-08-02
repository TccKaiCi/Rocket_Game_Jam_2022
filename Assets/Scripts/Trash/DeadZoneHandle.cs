using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneHandle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
