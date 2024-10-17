using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField] private CharacterController tankController;
    [SerializeField] private VariableJoystick moveJoyStick;
    [SerializeField] private float speedMove;
    private Vector3 moveDirection;

    public Vector3 MoveDirection { get => moveDirection;}


    public void MoveControl()
    {
        float hInput = moveJoyStick.Horizontal;
        float vInput = moveJoyStick.Vertical;
        moveDirection = new Vector3(hInput, 0, vInput);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        tankController.SimpleMove(MoveDirection * speedMove);
    }
    
}
