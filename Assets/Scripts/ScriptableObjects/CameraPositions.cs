using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraPositions", menuName = "ScriptableObjects/CameraPositions", order = 1)]
public class CameraPositions : ScriptableObject
{
    public CameraPosition DrivingPosition;
}

[Serializable]
public struct CameraPosition
{
    public Vector3 Position;
    public Vector3 Rotation;
}