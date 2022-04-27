using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ball", menuName = "ScriptableObjects/PathPoints")]

public class PathObjs : ScriptableObject
{
    public List<Transform> pathPoints;
}
