using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trash : MonoBehaviour
{
    public Type Type;
    public Information Information;
    public bool IsActiveInTrash_Bin = false;

    private void OnDisable()
    {
        GetComponent<Trash>().IsActiveInTrash_Bin = false;
    }
}
