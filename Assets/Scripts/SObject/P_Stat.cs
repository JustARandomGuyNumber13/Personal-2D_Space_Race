using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class P_Stat : ScriptableObject
{
    [SerializeField] private float normalMovementSpeed;
    [SerializeField] private float collisionDamageValue;
    private float currentMovementSpeed;
    private float currentDistance;
    private float trackLength;


    public float CollisionDamageValue
    {
        get { return collisionDamageValue; }
    }
    public float TrackLength
    { 
        get { return trackLength; }
        set { trackLength = value; }
    }
    public float CurrentDistance
    {
        get { return currentDistance; }
        set { currentDistance = value; }
    }
    public float CurrentMovementSpeed 
    {
        get { return currentMovementSpeed; }
        set { currentMovementSpeed = value; }
    }
    public float NormalMovementSpeed
    {
        get { return normalMovementSpeed; }
    }
}
