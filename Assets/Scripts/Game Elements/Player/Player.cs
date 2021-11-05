using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Base
{

    [SerializeField]
    private LayerMask jumpableGround;

    [HideInInspector]
    public MovementSM movementSm;

    private Rigidbody2D rBody;
    private BoxCollider2D bCollider;

    #region Attack/Combat
    [SerializeField] private GameObject bulletPF = null;
    #endregion

    void Awake()
    {
        this.rBody = GetComponent<Rigidbody2D>();
        this.bCollider = GetComponent<BoxCollider2D>();
        this.AddComponents();
    }

    private void AddComponents()
    {
        this.movementSm = gameObject.AddComponent(typeof(MovementSM)) as MovementSM;
    }

    void Update()
    {
    }

    protected override void InitializeAttributes()
    {
        type = ElementType.PLAYER;
        hp = 5f;
        basicAttack = 1f;
    }

    private void BasicAttack()
    {
        GameObject bullet = Instantiate(bulletPF, transform.position, Quaternion.identity);

    }
}