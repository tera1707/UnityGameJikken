using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float moveAmount = 4.0f;
    public float jumpAmount = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        // ‚Ô‚Â‚©‚Á‚Ä‚«‚½‘Šè‚ÌRigidBody‚ğæ“¾
        rb = gameObject.GetComponent<Rigidbody>();

        Physics.gravity *= 5;
    }

    // Update is called once per frame
    void Update()
    {
        float lx = Gamepad.current.leftStick.ReadValue().x;
        float ly = Gamepad.current.leftStick.ReadValue().y;
        float rx = Gamepad.current.rightStick.ReadValue().x;
        float ry = Gamepad.current.rightStick.ReadValue().y;

        if (Mathf.Abs(lx) > 0.001f)
        {
            transform.Translate(Vector3.right * lx * Time.deltaTime * moveAmount);
        }

        if (Mathf.Abs(ly) > 0.001f)
        {
            transform.Translate(Vector3.forward * ly * Time.deltaTime * moveAmount);
        }

        if (Mathf.Abs(rx) > 0.001f)
        {
            //transform.Translate(Vector3.right * lx * Time.deltaTime * moveAmount);
            transform.Rotate(0, rx, 0);
        }

        if (Gamepad.current.buttonEast.wasPressedThisFrame)
        {
            // ^ã‚ÉA‘Šè‚Ì¿—Ê‚Ì1000”{‚Ì—Í‚ğ‰Á‚¦‚é
            rb.AddForce(Vector3.up * rb.mass * jumpAmount, ForceMode.Impulse);
        }
    }
}