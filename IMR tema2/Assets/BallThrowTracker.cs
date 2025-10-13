using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable), typeof(Rigidbody))]
public class BallThrowTracker : MonoBehaviour
{
    public Vector3 releasePosition;
    public Vector3 releaseVelocity;

    XRGrabInteractable grab;
    Rigidbody rb;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        grab.selectExited.AddListener(OnReleased);
    }
    void OnDisable()
    {
        grab.selectExited.RemoveListener(OnReleased);
    }

    void OnReleased(SelectExitEventArgs _)
    {
        // where & how fast the ball was when you let go
        releasePosition = transform.position;
        releaseVelocity = rb.velocity;
    }
}
