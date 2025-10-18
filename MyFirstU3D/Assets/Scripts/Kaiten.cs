using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kaiten : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float lx = Gamepad.current.leftStick.ReadValue().x;
        float ly = Gamepad.current.leftStick.ReadValue().y;
        float rx = Gamepad.current.rightStick.ReadValue().x;
        float ry = Gamepad.current.rightStick.ReadValue().y;

        // X方向に一定量移動していれば横回転
        if (Mathf.Abs(rx) > 0.001f)
        {
            // 回転軸はワールド座標のY軸
            //transform.RotateAround(player.transform.position, Vector3.up, rx);
        }

        // Y方向に一定量移動していれば縦回転
        if (Mathf.Abs(ry) > 0.001f)
        {
            // 回転軸はカメラ自身のX軸
            transform.RotateAround(player.transform.position, transform.right, -ry);
        }
    }

    void OnGUI()
    {
        if (Gamepad.current == null) return;
        // 私のWindows＋私のコントローラーでは
        GUILayout.Label($"leftStick: {Gamepad.current.leftStick.ReadValue()}");         // 左アナログスティック
        GUILayout.Label($"rightStick: {Gamepad.current.rightStick.ReadValue()}");       // 右アナログスティック
        GUILayout.Label($"buttonNorth: {Gamepad.current.buttonNorth.isPressed}");       // Y(□)ボタン
        GUILayout.Label($"buttonSouth: {Gamepad.current.buttonSouth.isPressed}");       // A(〇)ボタン
        GUILayout.Label($"buttonEast: {Gamepad.current.buttonEast.isPressed}");         // B(×)ボタン
        GUILayout.Label($"buttonWest: {Gamepad.current.buttonWest.isPressed}");         // X(△)ボタン
        GUILayout.Label($"leftShoulder: {Gamepad.current.leftShoulder.ReadValue()}");   // Lボタン
        GUILayout.Label($"leftTrigger: {Gamepad.current.leftTrigger.ReadValue()}");     // ZLボタン
        GUILayout.Label($"rightShoulder: {Gamepad.current.rightShoulder.ReadValue()}"); // Rボタン
        GUILayout.Label($"rightTrigger: {Gamepad.current.rightTrigger.ReadValue()}");   // ZRボタン
    }
}