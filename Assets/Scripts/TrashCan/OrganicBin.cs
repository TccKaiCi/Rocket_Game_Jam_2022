using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganicBin : TrashCan
{
    public override void TakeTrash(Trash trash)
    {
        switch (trash.Type)
        {
            case Type.InOrganic:
                TakeTrash();
                TakeTrash();
                break;
            case Type.Organic:
                TakeTrash();
                break;
        }
    }

    private void Start() => base.Start();
}
