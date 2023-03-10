using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpEnemy;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private PlayerScript player;
    public TextMeshProUGUI shieldCountText;
    public TextMeshProUGUI DefenseCountText;
    public TextMeshProUGUI AttackCountText;
    public TextMeshProUGUI hpDamageText;
    public Image defenseImage;
    public Image attackImage;
    public TextMeshProUGUI hpCurrentText;
    public TextMeshProUGUI hpEnemyText;
    //public Animator animator;
    private SpriteRenderer sprRend;
    private int shieldCount = 0;
    private int attackCount;
    private int defenseCount;
    private int hpEnemy;
    private int hpCurrent;
    //private string nameEnemy;
    private int minAttackOrDefenseCount;
    private int maxAttackOrDefenseCount;
    private bool isAttack;
    //private int minAttackCount;
    //public int maxAttackCount;
    private void Awake()
    {
         WhatEnemy();
    }
    void Start()
    {        
        //animator = GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();
        hpCurrent = hpEnemy;
        shieldCountText.text = shieldCount.ToString();
        hpCurrentText.text = hpCurrent.ToString();
        hpEnemyText.text = "/    " + hpEnemy.ToString();      
        AttackOrDefence();  
    }
    public void WhatEnemy()
    {
        switch (name)
        {
            case "Enemy1":
                hpEnemy = 6;
                minAttackOrDefenseCount = 1;
                maxAttackOrDefenseCount = 2;
                Debug.Log($"nameEnemy+{name}, hpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
                break;

            case "Enemy2":
                hpEnemy = 8;
                minAttackOrDefenseCount = 1;
                maxAttackOrDefenseCount = 3;
                Debug.Log($"nameEnemy+{name},hpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
                break;

            case "Enemy3":
                hpEnemy = 10;
                minAttackOrDefenseCount = 1;
                maxAttackOrDefenseCount = 4;
                Debug.Log($"nameEnemy+{name},hpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
                break;

            case "Enemy4":
                hpEnemy = 12;
                minAttackOrDefenseCount = 2;
                maxAttackOrDefenseCount = 6;
                Debug.Log($"nameEnemy+{name},hpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
                break;

            case "Enemy5":
                hpEnemy = 15;
                minAttackOrDefenseCount = 3;
                maxAttackOrDefenseCount = 8;
                Debug.Log($"vhpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
                break;
        }
    }
    public void AttackOrDefence()
    {
        isAttack = Random.Range(0, 2) == 1;
        Debug.Log("isAttackEnemy: "+isAttack);

        if (isAttack == true)
        {
            attackCount = Random.Range(minAttackOrDefenseCount, maxAttackOrDefenseCount);
            StatusDisplayAttack();
        }
        else
        {
            defenseCount = Random.Range(minAttackOrDefenseCount, maxAttackOrDefenseCount);
            StatusDisplayDefense();
        }
    }
    private void StatusDisplayAttack()
    {
        attackImage.gameObject.SetActive(true);
        defenseImage.gameObject.SetActive(false);
        AttackCountText.text = attackCount.ToString();
    }
    private void StatusDisplayDefense()
    {   
        defenseImage.gameObject.SetActive(true);
        attackImage.gameObject.SetActive(false);
        DefenseCountText.text = defenseCount.ToString();
    }
    public void StartAttackOrDefenseEnemy()
    {
        if (isAttack == true)
        {
        player.Damage(attackCount);
        Invoke("AttackOrDefence",1f);

        }
        else
        {
        ShieldCount(defenseCount);
        Invoke("AttackOrDefence",1f);

        }
    }

    public void ShieldCount(int shield)
    {
        shieldCount += shield;
        shieldCountText.text = shieldCount.ToString();
    }
    private void HpDamage()
    {
        hpDamageText.enabled = false;
    }
    public void Damage(int damage)
    {
        if (shieldCount > 0 && damage >= shieldCount)//удар більше щита
        {
            hpCurrent = (hpCurrent + shieldCount) - damage;
            hpDamageText.text = "- " + (damage - shieldCount).ToString();
            hpDamageText.enabled = true;
            Invoke("HpDamage", 2f);
            shieldCount = 0;
            shieldCountText.text = shieldCount.ToString();
        }
        else if (shieldCount > 0 && damage < shieldCount)//удар менше щита
        {
            shieldCount -= damage;
            shieldCountText.text = shieldCount.ToString();         
        }
        else
        {
            hpCurrent = hpCurrent - damage;
        }
        hpCurrentText.text = hpCurrent.ToString();
        imageHpEnemy.fillAmount = (float)hpCurrent / hpEnemy;
        sprRend.color = colorDamage;

        if (hpCurrent <= 0)
        {
            Destroy(gameObject);            
            gameUI.TheEnd();
        }
        else
        {
            Invoke("ResetMaterial", 0.5f);
        }

    }
    void ResetMaterial()
    {
        sprRend.color = Color.white;
    }

}


