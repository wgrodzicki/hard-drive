using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 20.0f;

    void Update()
    {
        this.transform.Translate(Speed * Time.deltaTime * Vector3.forward);
    }
}
