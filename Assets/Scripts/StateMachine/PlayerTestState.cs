using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState {
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {
    }

    public override void Enter() {

    }

    public override void Tick(float deltaTime) {
        Vector3 moveDelta = CalculateMovement();
        stateMachine.CharacterController.Move(moveDelta.normalized * stateMachine.FreeLookMoveSpeed * deltaTime);

        if (stateMachine.InputReader.MoveVector != Vector2.zero) {
            stateMachine.transform.rotation = Quaternion.LookRotation(moveDelta);
        }
        stateMachine.Animator.SetFloat("FreeLookMoveSpeed", moveDelta.magnitude, 0.1f, deltaTime);
    }

    public override void Exit() {

    }

    private Vector3 CalculateMovement() {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.InputReader.MoveVector.y + right * stateMachine.InputReader.MoveVector.x;
    }
}
