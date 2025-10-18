using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float moveAmount = 4.0f;
    public float jumpAmount = 20.0f;

    // 設置チェック
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        // ぶつかってきた相手のRigidBodyを取得
        rb = gameObject.GetComponent<Rigidbody>();

        Physics.gravity *= 5;

        distance = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Rayが見たいので見るためだけに呼ぶ
        GetIsGrounded();

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
            if (GetIsGrounded())
            {
                // 真上に、相手の質量の1000倍の力を加える
                rb.AddForce(Vector3.up * rb.mass * jumpAmount, ForceMode.Impulse);
            }
        }
    }

    private bool GetIsGrounded()
    {
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        bool isGround = Physics.Raycast(ray, distance);
        Debug.DrawRay(rayPosition, Vector3.down * distance * 10, Color.red);

        return isGround;
    }
}