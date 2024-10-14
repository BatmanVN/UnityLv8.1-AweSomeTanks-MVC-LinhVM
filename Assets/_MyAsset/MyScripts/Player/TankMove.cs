using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField] private CharacterController tankController;
    [SerializeField] private GameObject baseTank;
    [SerializeField] private VariableJoystick joyStick;
    [SerializeField] private float speed;
    private void OnValidate() => tankController = GetComponent<CharacterController>();

    public void MoveControl()
    {
        float hInput = joyStick.Horizontal;
        float vInput = joyStick.Vertical;
        var direction = new Vector3(hInput, 0, vInput);
        direction = Camera.main.transform.TransformDirection(direction);
        direction.y = 0;
        tankController.SimpleMove(direction * speed);
        if (direction != Vector3.zero)
        {
            Quaternion targetRotate = Quaternion.LookRotation(direction);
            targetRotate.eulerAngles = new Vector3(0f, targetRotate.eulerAngles.y,0f);
            baseTank.transform.rotation = Quaternion.Slerp(baseTank.transform.rotation, targetRotate, 5 * Time.deltaTime);
        }
    }
    
}
