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
    [SerializeField] private TextMeshProUGUI hpCurrentText;
    [SerializeField] private TextMeshProUGUI hpEnemyText;
    [SerializeField] private GameMusicController gameMusicController;
    [SerializeField] private EnemyAllScript enemyAllScript;
    [SerializeField] private StatusDisplayAttackOrDefenseEnemy statusDisplayAttackOrDefense;
    private Image imageEnemy;
    private int shieldCount = 0;
    private int attackCount;
    private int defenseCount;
    private int hpEnemy;
    private int hpCurrent;
    private int minAttackOrDefenseCount;
    private int maxAttackOrDefenseCount;
    private bool isAttack;
    public Image shieldImageResultPlayer;
    private void Awake()
    {
        EnemyStart();
        GlobalControl.Instance.HpEnemyStart(hpEnemy);
        hpCurrent = GlobalControl.Instance.lifeEnemy;
        //Debug.Log("AwakeEnemy");
    }
    private void Start()
    {
        //Debug.Log("Start Enemy");
        imageEnemy = GetComponent<Image>();
        shieldCountScript.ShieldCountStart();
        hpEnemyText.text = "/    " + hpEnemy.ToString();
        ImageAndTextHpCurrent();
        AttackOrDefence();
    }
    private void EnemyStart()
    {
        enemyAllScript.WhatEnemy();
        hpEnemy = enemyAllScript.hpEnemy;
        minAttackOrDefenseCount = enemyAllScript.minAttackOrDefenseCount;
        maxAttackOrDefenseCount = enemyAllScript.maxAttackOrDefenseCount;

    }
    private void ImageAndTextHpCurrent()
    {
        hpCurrentText.text = hpCurrent.ToString();
        imageHpEnemy.fillAmount = (float)hpCurrent / hpEnemy;
    }  
    public void AttackOrDefence()
    {
        isAttack = Random.Range(0, 2) == 1;
        //Debug.Log("isAttackEnemy: " + isAttack);

        if (isAttack == true)
        {
            attackCount = Random.Range(minAttackOrDefenseCount, maxAttackOrDefenseCount);
            statusDisplayAttackOrDefense.StatusDisplayAttack(attackCount);
        }
        else
        {
            defenseCount = Random.Range(minAttackOrDefenseCount, maxAttackOrDefenseCount);
            statusDisplayAttackOrDefense.StatusDisplayDefense(defenseCount);
        }
    }
    //private void StatusDisplayAttack()
    //{
    //    attackImage.gameObject.SetActive(true);
    //    defenseImage.gameObject.SetActive(false);
    //    attackCountText.text = attackCount.ToString();
    //}
    //private void StatusDisplayDefense()
    //{
    //    defenseImage.gameObject.SetActive(true);
    //    attackImage.gameObject.SetActive(false);
    //    defenseCountText.text = defenseCount.ToString();
    //}
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

    public void Damage(int damage)
    {
        shieldCount = shieldCountScript.shieldCount;

        if (shieldCount > 0 && damage > shieldCount)//удар більше щита
        {
            hpCurrent = (hpCurrent + shieldCount) - damage;

            shieldCountScript.HpDamageTextCount(damage);
            shieldCountScript.ShieldCountStart();
        }
        else if (shieldCount > 0 && damage <= shieldCount)//удар менше щита
        {
            shieldCountScript.ShieldCountAfterDamage(damage);
        }
        else
        {
            hpCurrent = hpCurrent - damage;
        }
        GlobalControl.Instance.lifeEnemy = hpCurrent;
        PlayerPrefs.SetInt("LifeEnemy", hpCurrent);
       
        ImageAndTextHpCurrent();

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


