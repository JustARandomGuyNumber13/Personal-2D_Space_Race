using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class P_SkillHandler : MonoBehaviour
{
    [Header("Require Components")]
    [SerializeField] private P_Stat stat;
    [SerializeField] private Skill_Stat skill;

    private int skillType;
    private bool isOffensiveSkill;
    private bool isUsingSkill;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectSkill(collision);
    }


    private void CollectSkill(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Skill"))
        {
            AssignSkillType(collision.gameObject);
        }
    }
    private void AssignSkillType(GameObject skill)
    {
        if (skillType == 0)
        {
            switch (skill.tag)
            {
                case "Skill 1":
                    skillType = 1;
                    break;
                case "Skill 2":
                    skillType = 2;
                    break;
                case "Skill 3":
                    skillType = 3;
                    break;
            }
            isOffensiveSkill = false;
        }
    }
    public void UseSkill()
    {
        if (skillType != 0 && !isUsingSkill)
        {
            isUsingSkill = true;
            switch (skillType)
            {
                case 1:
                    ShrinkSkill();
                    break;
                case 2:
                    ShieldSkill();
                    break;
                case 3:
                    SpeedSkill();
                    break;
            }
            skillType = 0;
        }
    }


    private void SpeedSkill()
    {
        isUsingSkill = false;
    }
    private void SpeedSkillRevert()
    { 
    
    }
    private void ShieldSkill()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
        stat.CurrentMovementSpeed = skill.ShieldMoveSpeed;
        Invoke("ShieldSkillRevert", skill.ShieldDuration);
    }
    private void ShieldSkillRevert()
    {
        isUsingSkill = false;
        stat.CurrentMovementSpeed = stat.NormalMovementSpeed;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
    }
    private void ShrinkSkill()
    {
        transform.localScale -= new Vector3(skill.ShrinkScaleMinus, skill.ShrinkScaleMinus);
        stat.CurrentMovementSpeed = skill.ShrinkMoveSpeed;
        Invoke("ShrinkSkillRevert", skill.ShrinkDuration);
    }
    private void ShrinkSkillRevert()
    {
        isUsingSkill = false;
        transform.localScale += new Vector3(skill.ShrinkScaleMinus, skill.ShrinkScaleMinus);
        stat.CurrentMovementSpeed = stat.NormalMovementSpeed;
    }
}
