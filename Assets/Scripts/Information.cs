using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "ScriptableObject")]
public class Information : ScriptableObject
{
    public string Name;
    public string Description;
    public int Cost;
}
