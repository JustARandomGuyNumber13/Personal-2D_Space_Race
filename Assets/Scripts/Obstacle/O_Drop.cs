using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class O_Drop : MonoBehaviour
{
    [Header("Base setting")]
    [SerializeField] private float minDropSpeed;
    [SerializeField] private float maxDropSpeed;
    [Header("Rotate setting")]
    [SerializeField] private bool isRotateOnStart;
    [SerializeField] private float rotateMinForce, rotateMaxForce;
    [Header("Launch horizontal setting")]
    [SerializeField] private bool isLaunchHorizontalOnStart;
    [SerializeField] private float minLaunchForce, maxLaunchForce;


    protected Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected void Start()
    {
        DropDown();
        RotateOnStart();
        LaunchHorizontalOnStart();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layer = collision.gameObject.layer;
        CheckWall(layer);
        CheckDestroy(layer);
    }

    private void DropDown()
    { 
        float dropSpeed = Random.Range(minDropSpeed, maxDropSpeed);
        rb.velocity = new Vector2 (rb.velocity.x, -dropSpeed);
    }
    private void RotateOnStart()
    {
        if (isRotateOnStart)
        {
            float rotateSpeed = Random.Range(rotateMinForce, rotateMaxForce);
            float rotateDirection = Random.Range(0, 2);
            rb.AddTorque(rotateSpeed * (rotateDirection >= 1 ? 1 : -1));
        }
    }
    private void LaunchHorizontalOnStart()
    {
        if (isLaunchHorizontalOnStart)
        { 
            float launchForce = Random.Range(minLaunchForce, maxLaunchForce);
            float launchDir = Random.Range(0, 2);
            rb.AddForce(Vector2.right * launchForce * (launchDir >= 1 ? 1 : -1));
        }
    }
    private void CheckWall(int layer)
    {
        if (layer == LayerMask.NameToLayer("Wall"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }
    private void CheckDestroy(int layer)
    {
        if (layer == LayerMask.NameToLayer("Player") ||
        layer == LayerMask.NameToLayer("Destroyer"))
        {
            Destroy(this.gameObject);
        }
    }
} 
