using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class TrashCan : MonoBehaviour
{
    public Type Type;
    public Information Information;
    public int MaxCapacity;
    public int CurrentCapacity;
    public bool IsFull => CurrentCapacity == 0;
    public void TakeTrash() { if (this.IsFull) { Debug.Log("Trash can is full"); } else { DecreaseCapacity(); } }
    public abstract void TakeTrash(Trash trash);
    private void IncreaseCapacity() => this.CurrentCapacity = Mathf.Clamp(this.CurrentCapacity + 1, 0, this.MaxCapacity);
    private void DecreaseCapacity() => this.CurrentCapacity = Mathf.Clamp(this.CurrentCapacity - 1, 0, this.MaxCapacity);

    protected virtual void Start()
    {
        CurrentCapacity = MaxCapacity;
        gameObject.AddComponent<TrashTouchBin>();
    }
}
