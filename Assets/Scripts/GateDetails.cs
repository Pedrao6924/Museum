using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "ScriptableObjects/GateInfo", order = 1)]
public class GateDetails : MonoBehaviour
{
   public GameObject nextRoom;
   public GameObject currentRoom;
}
