using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State {

  protected SO_MoveState stateData;
  protected bool isDetectingWall;
  protected bool isDetectingLedge;
  protected bool isPlayerInMinAggroRange;

  public MoveState(
    Entity entity, 
    FiniteStateMachine stateMachine, 
    string animBoolName,
    SO_MoveState stateData
    ) : base(entity, stateMachine, animBoolName) {
      this.stateData = stateData;
  }

  public override void Enter() {
    base.Enter();
    entity.SetVelocity(stateData.movementSpeed);

    isDetectingLedge = entity.CheckLedge();
    isDetectingWall = entity.CheckWall();
    isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
  }

  public override void Exit() {
    base.Exit();
  }

  public override void LogicUpdate() {
    base.LogicUpdate();
  }

  public override void PhysicsUpdate() {
    base.PhysicsUpdate();

    isDetectingLedge = entity.CheckLedge();
    isDetectingWall = entity.CheckWall();
    isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
  }
}
