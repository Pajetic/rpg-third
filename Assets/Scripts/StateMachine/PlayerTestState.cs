using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState {
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) {
    }

    public override void Enter() {

    }

    public override void Tick(float deltaTime) {
        Vector3 moveDelta = Vector3.zero;
        moveDelta.x = stateMachine.InputReader.MoveVector.x;
        moveDelta.z = stateMachine.InputReader.MoveVector.y;
        stateMachine.CharacterController.Move(moveDelta * stateMachine.MoveSpeed * deltaTime);

        if (stateMachine.InputReader.MoveVector != Vector2.zero) {
            stateMachine.transform.rotation = Quaternion.LookRotation(moveDelta);
        }
    }

    public override void Exit() {

    }
}
