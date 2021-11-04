using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  [SerializeField] 
  private LayerMask jumpableGround;

  [HideInInspector]
  public MovementSM movementSm;

  private Rigidbody2D rBody;
  private BoxCollider2D bCollider;

  void Awake() {
    this.rBody = GetComponent<Rigidbody2D>();
    this.bCollider = GetComponent<BoxCollider2D>();
    this.AddComponents();
  }

  private void AddComponents() {
    this.movementSm = gameObject.AddComponent(typeof(MovementSM)) as MovementSM;
  }

  void Update() {
  }
}