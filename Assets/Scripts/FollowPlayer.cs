using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private CameraPositions _cameraPositions;

    void Start()
    {
        this.transform.SetPositionAndRotation(_cameraPositions.DrivingPosition.Position, Quaternion.Euler(_cameraPositions.DrivingPosition.Rotation));
        this.transform.parent = _player.transform;
    }
}
