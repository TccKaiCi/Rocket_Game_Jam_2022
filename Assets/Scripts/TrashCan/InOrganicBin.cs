using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOrganicBin : TrashCan, ITakeInOrganicTrash
{
    public void TakeTrash(InOrganicTrash inOrganicTrash) => base.TakeTrash();

    private void Start()
    {
        base.Type = Type.InOrganic;
        gameObject.AddComponent<TrashTouchBin>();
    }
}
