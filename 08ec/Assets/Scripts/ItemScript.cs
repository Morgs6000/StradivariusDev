using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/New Item", order = 0)]
public class ItemScript : ScriptableObject {
    //public Sprite sprite;
    public Vector2 getUV;
    public EnumItems itemID;
}
