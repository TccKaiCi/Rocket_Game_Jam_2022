using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOrganicBin : TrashCan
{
    public override void TakeTrash(Trash trash)
    {
        switch (trash.Type)
        {
            case Type.InOrganic:
                TakeTrash();
                break;
            case Type.Organic:
                TakeTrash();
                TakeTrash();
                break;
        }
    }

    private void Start() => base.Start();
}
