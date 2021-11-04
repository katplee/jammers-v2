using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSM : StateMachine {

  [HideInInspector]
  public Idle idleState;
  [HideInInspector]
  public Moving movingState;
  [HideInInspector]
  public Jumping jumpingState;
  [HideInInspector] 
  public Vector2 movementInput { get; private set; }
  [HideInInspector]
  public float horizontalVelocity = 0f;
  //@Todo prob want to convert an Entity class or IMoveable instead of a Player
  [HideInInspector]
  public Player player;

  public Rigidbody2D rBody;
  public float speed = 13f;
  public float jumpForce = 20f;
  public bool isFacingRight = true;

  private void Awake() {
    this.AddInputBindings();
    this.idleState = new Idle(this);
    this.movingState = new Moving(this);
    this.jumpingState = new Jumping(this);
    this.rBody = GetComponent<Rigidbody2D>();
    this.player = GetComponent<Player>();
  }

  //@Todo might want to init this only for our Player ? 
  private void AddInputBindings() {

    //@Todo prob want to move to protected/public access if we need to access this elsewhere
    var map = new InputActionMap("player-land");
    var moveAction = map.AddAction("move");
    moveAction.AddBinding("<Gamepad>/leftStick");
    moveAction.AddCompositeBinding("2DVector")
      .With("Up", "<Keyboard>/w")
      .With("Down", "<Keyboard>/s")
      .With("Left", "<Keyboard>/a")
      .With("Right", "<Keyboard>/d");
 
    moveAction.performed += ctx => {
      this.movingState.MoveEntity(ctx);
      this.ChangeState(((MovementSM) this).movingState);
    };
    moveAction.canceled += ctx => {
      this.ChangeState(((MovementSM) this).idleState);
    };

    var jumpAction = map.AddAction("jump");
    jumpAction.AddBinding("<Gamepad>/buttonSouth");
    jumpAction.AddBinding("<Keyboard>/space");
    jumpAction.performed += ctx => {
      this.ChangeState(((MovementSM) this).jumpingState);
    };
    //@Todo figure out how to cancel jumping state so that if user taps button it will do a small jump?
    // jumpAction.canceled += ctx => {
    //   //@Todo prob want a 'falling' state here
    //   this.ChangeState(((MovementSM) this).idleState);
    // };
    
    map.Enable();
  }

  protected override BaseState GetInitialState() {
    return idleState;
  }

}
