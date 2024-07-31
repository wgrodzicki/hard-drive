using System;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    public bool IsTouchingGround {  get; private set; }

    public Action OnTouchedGround;
    public Action OnLeftGround;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            IsTouchingGround = true;
            OnTouchedGround?.Invoke();
        }            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            IsTouchingGround = false;
            OnLeftGround?.Invoke();
        }
    }
}
