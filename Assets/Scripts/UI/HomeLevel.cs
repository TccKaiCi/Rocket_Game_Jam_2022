using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;

public class HomeLevel : MonoBehaviour
{
    public float Timer = 1.5f;
    private void Start() => MessageBroker.Default.Receive<HomeLevelEvent>().Subscribe(eventHandle => { ChangePanel(eventHandle.panelA, eventHandle.panelB); });


    public void ChangePanel(GameObject panelA, GameObject panelB)
    {
        MovePanel(panelA, panelB);
        MovePanel(panelB, panelA);
    }

    public void MovePanel(GameObject panelA, GameObject panelB) => DOTween.To(() => panelA.transform.position, x => panelA.transform.position = x, new Vector3(panelB.transform.position.x, panelB.transform.position.y, panelB.transform.position.z), Timer);

}
