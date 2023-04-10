using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EnemyAllScript : MonoBehaviour
{
    [SerializeField] private int _hpEnemy;
    [SerializeField] private int _minAttackOrDefenseCount;
    [SerializeField] private int _maxAttackOrDefenseCount;
   
    public int HpEnemy { get => _hpEnemy; set => _hpEnemy = value; }

    public int MinAttackOrDefenseCount { get => _minAttackOrDefenseCount; private set => _minAttackOrDefenseCount = value; }

    public int MaxAttackOrDefenseCount { get => _maxAttackOrDefenseCount; private set => _maxAttackOrDefenseCount = value; }

    public void WhatEnemy()
    {
        switch (name)
        {
            case "Enemy1":
                HpEnemy = 6;
                MinAttackOrDefenseCount = 1;
                MaxAttackOrDefenseCount = 2;
                break;

            case "Enemy2":
                HpEnemy = 8;
                MinAttackOrDefenseCount = 1;
                MaxAttackOrDefenseCount = 3;
                break;

            case "Enemy3":
                HpEnemy = 10;
                MinAttackOrDefenseCount = 1;
                MaxAttackOrDefenseCount = 4;
                break;

            case "Enemy4":
                HpEnemy = 12;
                MinAttackOrDefenseCount = 2;
                MaxAttackOrDefenseCount = 6;
                break;

            case "Enemy5":
                HpEnemy = 15;
                MinAttackOrDefenseCount = 3;
                MaxAttackOrDefenseCount = 8;
                break;
        }
        //Debug.Log($"nameEnemy+{name}, hpEnemy: {hpEnemy}, minAttackOrDefenseCount: {minAttackOrDefenseCount}, maxAttackOrDefenseCount: {maxAttackOrDefenseCount}");
    }
}
