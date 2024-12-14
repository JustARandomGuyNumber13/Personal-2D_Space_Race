using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_SkillHandler : MonoBehaviour
{
    [Header("Require Components")]
    [SerializeField] private P_Stat stat;
    [SerializeField] private Skill_Stat skill;
    [SerializeField]private GameObject shield;

    private int skillType;
    private Rigidbody2D rb;
    private bool isUsingSkill;
    //private bool isOffensiveSkill;


    /* Monobehavior methods *////////////////////////////////////////////////////////////////////////////
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectSkill(collision);
        CollisionHandler(collision);
    }


    /* Other handlers */
    private void CollisionHandler(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && !shield.activeInHierarchy)
            stat.CurrentDistance -= stat.CollisionDamageValue;
    }
    private void CollectSkill(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Skill"))
            AssignSkillType(collision.gameObject.tag);
    }
    private void AssignSkillType(string skillTag)  // Get skill type by tag
    {
        if (skillType != 0)
            return;

        switch (skillTag)
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
        //isOffensiveSkill = false;
    }
    public void UseSkill()
    {
        if (skillType == 0 || isUsingSkill)
            return;

        switch (skillType)
        {
            case 1:
                UseShrinkSkill();
                break;
            case 2:
                UseShieldSkill();
                break;
            case 3:
                UseSpeedSkill();
                break;
        }
        isUsingSkill = true;
        skillType = 0;
    }


    /* Skills behavior handlers */////////////////////////////////////////////////////////////////////
    private void UseSpeedSkill()
    {
        
    }
    private void SpeedSkillRevert()
    {
        isUsingSkill = false;
    }
    private void UseShieldSkill()
    {
        shield.SetActive(true);
        stat.CurrentMovementSpeed = skill.ShieldMoveSpeed;
        Invoke("ShieldSkillRevert", skill.ShieldDuration);
    }
    private void ShieldSkillRevert()
    {
        shield.SetActive(false);
        stat.CurrentMovementSpeed = stat.NormalMovementSpeed;
        isUsingSkill = false;
    }
    private void UseShrinkSkill()
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
