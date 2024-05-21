using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Skill_Stat : ScriptableObject
{
    [Header("Shrink Skill")]
    [SerializeField] private float shrinkScaleMinus;
    [SerializeField] private float shrinkDuration;
    [SerializeField] private float shrinkMoveSpeed;

    [Header("ShieldSkill")]
    [SerializeField] private float shieldDuration;
    [SerializeField] private float shieldMoveSpeed;

    public float ShrinkScaleMinus { get { return shrinkScaleMinus; } }
    public float ShrinkDuration { get { return shrinkDuration; } }
    public float ShrinkMoveSpeed { get {  return shrinkMoveSpeed; } }

    public float ShieldDuration { get { return shieldDuration; } }
    public float ShieldMoveSpeed { get { return shieldMoveSpeed; } }
}
