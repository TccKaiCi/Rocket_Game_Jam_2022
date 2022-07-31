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
            var trash = collider.GetComponent<Trash>();

            Debug.Log(GetComponent<TrashCan>().Type.ToString());

            switch (trash.Type)
            {
                case Type.InOrganic:
                    gameObject.GetComponent<ITakeInOrganicTrash>().TakeTrash(trash as InOrganicTrash);
                    break;
                case Type.Organic:
                    gameObject.GetComponent<ITakeOrganicTrash>().TakeTrash(trash as OrganicTrash);
                    break;
                default:
                    Destroy(collider, 0.5f);
                    break;
            }
        }
    }
}
