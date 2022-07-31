using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicTrash : Trash
{
    private void Start()
    {
        base.Type = Type.Organic;
    }
}
