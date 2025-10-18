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
            if (transform.eulerAngles.x < 5f && ry < 0)
            {
                ry = 0;
            }
            if (transform.eulerAngles.x > 30f && ry > 0)
            {
                ry = 0;
            }

            // 回転軸はカメラ自身のX軸
            transform.RotateAround(player.transform.position, transform.right, ry);
        }
    }

    void OnGUI()
    {
        if (Gamepad.current == null) return;

        GUIStyle largeStyle = new GUIStyle(GUI.skin.label);
        largeStyle.fontSize = 60; // お好みのサイズに変更可能

        // 私のWindows＋私のコントローラーでは
        GUILayout.Label($"leftStick: {Gamepad.current.leftStick.ReadValue()}", largeStyle);         // 左アナログスティック
        GUILayout.Label($"rightStick: {Gamepad.current.rightStick.ReadValue()}", largeStyle);       // 右アナログスティック
        GUILayout.Label($"buttonNorth: {Gamepad.current.buttonNorth.isPressed}", largeStyle);       // Y(□)ボタン
        GUILayout.Label($"buttonSouth: {Gamepad.current.buttonSouth.isPressed}", largeStyle);       // A(〇)ボタン
        GUILayout.Label($"buttonEast: {Gamepad.current.buttonEast.isPressed}", largeStyle);         // B(×)ボタン
        GUILayout.Label($"buttonWest: {Gamepad.current.buttonWest.isPressed}", largeStyle);         // X(△)ボタン
        GUILayout.Label($"leftShoulder: {Gamepad.current.leftShoulder.ReadValue()}", largeStyle);   // Lボタン
        GUILayout.Label($"leftTrigger: {Gamepad.current.leftTrigger.ReadValue()}", largeStyle);     // ZLボタン
        GUILayout.Label($"rightShoulder: {Gamepad.current.rightShoulder.ReadValue()}", largeStyle); // Rボタン
        GUILayout.Label($"rightTrigger: {Gamepad.current.rightTrigger.ReadValue()}", largeStyle);   // ZRボタン

        GUILayout.Label($"x: {transform.eulerAngles.x}", largeStyle);
        GUILayout.Label($"y: {transform.eulerAngles.y}", largeStyle);
        GUILayout.Label($"z: {transform.eulerAngles.z}", largeStyle);

    }
}