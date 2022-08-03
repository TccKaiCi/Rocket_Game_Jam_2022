using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTouchBin : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="collider">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(Tag.Trash.ToString()))
        {
            if (!collider.GetComponent<Trash>().IsActiveInTrash_Bin)
            {
                gameObject.GetComponent<TrashCan>().TakeTrash(collider.GetComponent<Trash>());
                collider.GetComponent<Trash>().IsActiveInTrash_Bin = true;
            }
        }
    }
}
