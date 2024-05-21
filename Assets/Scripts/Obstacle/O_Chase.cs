using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Chase : O_Drop
{
    [Header("Chase Player setting")]
    [SerializeField] private float xMinChaseSpeed;
    [SerializeField] private float xMaxChaseSpeed;

    private float xChaseSpeed;
    private Transform player;

    new private void Start()
    {
        base.Start();
        xChaseSpeed = Random.Range(xMinChaseSpeed, xMaxChaseSpeed);    
    }
    private void Update()
    {
        if (player != null)
        {
            if (transform.position.y > player.position.y)
            {
                ChasePlayer();
                LookAtPlayer();
            }
            else
            {
                LookDown();
            }
        }
    }
    private void ChasePlayer()
    {
        rb.velocity = new Vector2(transform.position.x < player.position.x ? xChaseSpeed : -xChaseSpeed, rb.velocity.y);
    }
    private void LookAtPlayer()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg - 90);
    }
    private void LookDown()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 180), Time.deltaTime * 3);
    }
    public void Public_AssignTransform(Transform player)
    { 
        this.player = player;
    }
}
