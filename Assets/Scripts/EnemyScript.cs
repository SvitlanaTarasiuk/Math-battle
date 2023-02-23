using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpEnemy;
    [SerializeField] private GameUI gameUI;
    //public Animator animator;
    private SpriteRenderer sprRend;   
    private int hpEnemy;
    private int hpCurrent;
    void Start()
    {
        //animator = GetComponent<Animator>();
        sprRend = GetComponent<SpriteRenderer>();       
        hpCurrent = hpEnemy;
    }
    void Update()
    {
        
    }
   
    private void Damage()
    {

        //if ()
        {
            hpCurrent--;
            imageHpEnemy.fillAmount = (float)hpCurrent / hpEnemy;
            sprRend.color = colorDamage;

            if (hpCurrent <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                gameUI.TheEnd();


            }
            else
            {
                Invoke("ResetMaterial", 0.5f);
            }
        }

    }
    void ResetMaterial()
    {
        sprRend.color = Color.white;
    }
    
}


