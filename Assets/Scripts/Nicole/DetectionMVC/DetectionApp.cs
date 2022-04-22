// Written by Soojung
// 4-21-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionApp : MonoBehaviour
{
    DetectionModel model;
    DetectionView view;
    DetectionController controller;
}

public class Element : DetectionApp
{
    Bound bound;
}
