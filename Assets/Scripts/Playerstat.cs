using System;
using UnityEngine;

[Serializable]
public class Playerstat
{
    [field:SerializeField] public float PerShot { get; set; }
    [field:SerializeField] public float Max { get; set; }
    [field:SerializeField] public float AutoShot { get; set; }
    [field:SerializeField] public int Money { get; set; }
}
