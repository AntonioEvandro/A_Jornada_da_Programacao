using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventario", menuName = "ScriptableObject/Inventory")]
public class Inventory : ScriptableObject
{
    public string Name;
    [TextArea(3,6)]
    public string Description;
    public int id;
}
