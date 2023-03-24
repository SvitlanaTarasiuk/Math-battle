using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpEnemy;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private PlayerScript player;
    [SerializeField] private ShieldCountScript shieldCountScript;
    public TextMeshProUGUI shieldCountText;
    public TextMeshProUGUI defenseCountText;
    public TextMeshProUGUI attackCountText;
    public TextMeshProUGUI hpDamageText=null;
    public Image defenseImage;
    public Image attackImage;
    public Image shieldImageResultPlayer;
    private Image imageEnemy;
    public TextMeshProUGUI hpCurrentText;
    public TextMeshProUGUI hpEnemyText;
    public GameMusicController gameMusicController;
    private int shieldCount = 0;
    private int attackCount;
    private int defenseCount;
    private int hpEnemy;//****
    private int hpCurrent;//****
    private int minAttackOrDefenseCount;
    private int maxAttackOrDefenseCount;
    private bool isAttack;
    private void Awake()
    {
        WhatEnemy();
        GlobalControl.Instance.HpEnemyStart(hpEnemy);
        hpCurrent = GlobalControl.Instance.lifeEnemy;
    }
    void Start()
    {
        Debug.Log("Start Enemy");
        imageEnemy = GetComponent<Image>();
        shieldCountScript.ShieldCountStart();
        hpEnemyText.text = "/    " + hpEnemy.ToString();
        HpCurrentUIEnemy();
        AttackOrDefence();
    }
    public void HpCurrentUIEnemy()
    {
        hpCurrentText.text = hpCurrent.ToString();
        imageHpEnemy.fillAmount = (float)hpCurrent / hpEnemy;
        Debug.Log("HpCurrentUIEnemy");
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
                Debug.Log($"nameEnemy+{name},hhpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
                break;
        }
    }
    public void AttackOrDefence()
    {
        isAttack = Random.Range(0, 2) == 1;
        Debug.Log("isAttackEnemy: " + isAttack);

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
        attackCountText.text = attackCount.ToString();
    }
    private void StatusDisplayDefense()
    {
        defenseImage.gameObject.SetActive(true);
        attackImage.gameObject.SetActive(false);
        defenseCountText.text = defenseCount.ToString();
    }
    public void StartAttackOrDefenseEnemy()
    {
        if (isAttack == true)
        {
            //AudioManagerMixer.instance.DamageEffect();
            gameMusicController.DamageEffectMusic();
            player.Damage(attackCount);
            Invoke("AttackOrDefence", 0.5f);
        }
        else
        {
            //AudioManagerMixer.instance.ShieldEffect();
            gameMusicController.ShieldEffectMusic();
            shieldCountScript.ShieldCountGame(defenseCount);
            Invoke("AttackOrDefence", 0.5f);
        }
    }
  
    private void HpDamage()
    {
        hpDamageText.text = null;
    }
    public void Damage(int damage)
    {
        if (shieldCount > 0 && damage >= shieldCount)//удар більше щита
        {
            hpCurrent = (hpCurrent + shieldCount) - damage;
           
            hpDamageText.text = "- " + (damage - shieldCount).ToString();        
            Invoke(nameof(HpDamage), 1.0f);
            
            shieldCountScript.ShieldCountStart();
        }
        else if (shieldCount > 0 && damage < shieldCount)//удар менше щита
        {
            shieldCountScript.ShieldCountAfterDamage(damage);
        }
        else
        {
            hpCurrent = hpCurrent - damage;
        }
        GlobalControl.Instance.lifeEnemy = hpCurrent;
        PlayerPrefs.SetInt("LifeEnemy", hpCurrent);
       
        HpCurrentUIEnemy();
        imageEnemy.color = colorDamage;

        if (hpCurrent <= 0)
        {
            Destroy(gameObject);
            gameUI.TheEnd();
        }
        else
        {
            Invoke(nameof(ResetMaterial), 0.5f);
        }
    }
    private void ResetMaterial()
    {
        imageEnemy.color = Color.white;
    }

}


