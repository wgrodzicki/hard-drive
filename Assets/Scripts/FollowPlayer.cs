using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    void Start()
    {
        this.transform.position = _player.transform.position;
        this.transform.parent = _player.transform;
    }
}
