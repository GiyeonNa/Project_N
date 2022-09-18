using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DropItem : ScriptableObject
{
    public enum Type { Food, Ammo, Money}
    public Type type;
    public string name;
    public int amount;
    public GameObject prefab;

    public abstract void Drop(Transform transform);
    
}
