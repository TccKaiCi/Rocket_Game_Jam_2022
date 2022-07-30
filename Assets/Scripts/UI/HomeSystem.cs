using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class HomeSystem : MonoBehaviour
{
    public GameObject panelA, panelB;
    public void ChangePositionPanel_A_B() => MessageBroker.Default.Publish(new HomeLevelEvent { panelA = this.panelA, panelB = this.panelB });
    public void ChangePositionPanel_B_A() => MessageBroker.Default.Publish(new HomeLevelEvent { panelB = this.panelA, panelA = this.panelB });

}