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
    //[SerializeField] private GameMusicController gameMusicController;
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
    private float timerInvokeResetMaterial = 0.5f;
    private float timerInvokeAttackOrDefence = 0.5f;
    private float timerInvokeStartAttackOrDefenseEnemy = 0.5f;

    private void Awake()
    {
        EnemyStart();
        GlobalControl.Instance.HpEnemyStart(hpEnemy);
        hpCurrent = GlobalControl.Instance.LifeEnemy;
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
        hpEnemy = enemyAllScript.HpEnemy;
        minAttackOrDefenseCount = enemyAllScript.MinAttackOrDefenseCount;
        maxAttackOrDefenseCount = enemyAllScript.MaxAttackOrDefenseCount;
    }

    private void ImageAndTextHpCurrent()
    {
        hpCurrentText.text = hpCurrent.ToString();
        imageHpEnemy.fillAmount = (float)hpCurrent / hpEnemy;
    }

    private void AttackOrDefence()
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

    public void StartAttackOrDefenseEnemyInvoke()
    {
        Invoke(nameof(StartAttackOrDefenseEnemy), timerInvokeStartAttackOrDefenseEnemy);
    }
    private void StartAttackOrDefenseEnemy()
    {
        if (isAttack == true)
        {
            AudioManagerMixer.Instance.DamageEffect();
            //gameMusicController.DamageEffectMusic();
            player.Damage(attackCount);
            Invoke(nameof(AttackOrDefence), timerInvokeAttackOrDefence);
        }
        else
        {
            AudioManagerMixer.Instance.ShieldEffect();
            //gameMusicController.ShieldEffectMusic();
            shieldCountScript.ShieldCountGame(defenseCount);
            Invoke(nameof(AttackOrDefence), timerInvokeAttackOrDefence);
        }
    }

    public void Damage(int damage)
    {
        shieldCount = shieldCountScript.ShieldCount;

        if (shieldCount > 0 && damage > shieldCount)//hit more shield
        {
            hpCurrent = (hpCurrent + shieldCount) - damage;

            shieldCountScript.HpDamageTextCount(damage);
            shieldCountScript.ShieldCountStart();
        }
        else if (shieldCount > 0 && damage <= shieldCount)//hit less shield
        {
            shieldCountScript.ShieldCountAfterDamage(damage);
        }
        else
        {
            hpCurrent = hpCurrent - damage;
        }
        GlobalControl.Instance.LifeEnemy = hpCurrent;
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
            Invoke(nameof(ResetMaterial), timerInvokeResetMaterial);
        }
    }

    private void ResetMaterial() => imageEnemy.color = Color.white;

}


