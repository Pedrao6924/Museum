using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "ScriptableObjects/PaintingInfo", order = 1)]
public class PaintingDetails : MonoBehaviour
{
    public int paintingID;
    public int watchTime;
    public string infoText = "This is the painting info you want to read!:)";
  
}
