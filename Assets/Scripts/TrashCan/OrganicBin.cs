using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicBin : TrashCan, ITakeOrganicTrash
{
    public void TakeTrash(OrganicTrash organicTrash) => base.TakeTrash();

    private void Start()
    {
        base.Type = Type.Organic;
        gameObject.AddComponent<TrashTouchBin>();
    }
}
