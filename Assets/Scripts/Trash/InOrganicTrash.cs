using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOrganicTrash : Trash
{
    private void Start()
    {
        base.Type = Type.InOrganic;
    }
}
