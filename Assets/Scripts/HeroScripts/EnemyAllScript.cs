using UnityEngine;

public class EnemyAllScript : MonoBehaviour
{
    public int hpEnemy;
    public int minAttackOrDefenseCount;
    public int maxAttackOrDefenseCount;

    public void WhatEnemy()
    {
        switch (name)
        {
            case "Enemy1":
                hpEnemy = 6;
                minAttackOrDefenseCount = 1;
                maxAttackOrDefenseCount = 2;               
                break;

            case "Enemy2":
                hpEnemy = 8;
                minAttackOrDefenseCount = 1;
                maxAttackOrDefenseCount = 3;
                break;

            case "Enemy3":
                hpEnemy = 10;
                minAttackOrDefenseCount = 1;
                maxAttackOrDefenseCount = 4;
                break;

            case "Enemy4":
                hpEnemy = 12;
                minAttackOrDefenseCount = 2;
                maxAttackOrDefenseCount = 6;
                break;

            case "Enemy5":
                hpEnemy = 15;
                minAttackOrDefenseCount = 3;
                maxAttackOrDefenseCount = 8;
                break;
        }
        //Debug.Log($"nameEnemy+{name}, hpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
    }
}
