using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(P_SkillHandler))]
public class P_PlayerHandler : MonoBehaviour
{
    [Header("Require Components")]
    [SerializeField] P_SkillHandler skillHandler;
    [SerializeField] P_Stat stat;

    private Vector2 movementInput;
    private Rigidbody2D rb;


    /* Monobehavior methods */////////////////////////////////////////////////////////////////////////
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stat.CurrentMovementSpeed = stat.NormalMovementSpeed;
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }


    /* Input handlers *////////////////////////////////////////////////////////////////////////////////////
    private void OnMovement(InputValue i)
    {
        movementInput = i.Get<Vector2>();
    }
    private void OnUseSkill()
    {
        skillHandler.UseSkill();
    } 


    /* Other handlers *////////////////////////////////////////////////////////////////////////////////////
    // Collision handler is at P_SkillHandler.cs
    private void PlayerMovement()
    {
        rb.linearVelocity = movementInput * stat.CurrentMovementSpeed;
    }
}
