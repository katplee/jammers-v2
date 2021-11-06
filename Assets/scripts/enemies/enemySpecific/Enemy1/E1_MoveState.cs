using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : MoveState {

  private Enemy1 enemy;

  public E1_MoveState(
    Entity entity, 
    FiniteStateMachine stateMachine, 
    string animBoolName, 
    SO_MoveState stateData,
    Enemy1 enemy
  ) : base(entity, stateMachine, animBoolName, stateData) {
    this.enemy = enemy;
  }

  public override void Enter() {
    base.Enter();
    Debug.Log("[Enemy1] -> enter E1_MoveState");
  }

  public override void Exit() {
    base.Exit();
  }

  public override void LogicUpdate() {
    base.LogicUpdate();

    if (isPlayerInMinAggroRange) {
      stateMachine.ChangeState(enemy.playerDetectedState);
    } else if (isDetectingWall || !isDetectingLedge) {
      enemy.idleState.SetFlipAfterIdle(true);
      stateMachine.ChangeState(enemy.idleState);
    }
  }

  public override void PhysicsUpdate() {
    base.PhysicsUpdate();
  }

}