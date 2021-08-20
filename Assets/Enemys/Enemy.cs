using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Reward/Punishment Settings")]
    [Tooltip("Gold gained when enemy is destoryed")]
    [SerializeField] int goldReward = 25;
    [Tooltip("Gold lost when enemy reaches end of path")]
    [SerializeField] int goldPenalty = 25;

    ManaBank bank;

    void Start()
    {
        bank = FindObjectOfType<ManaBank>();
    }

    public void RewardGold()
    {
        if(bank == null) 
        {
            return;
        }
        bank.Deposit(goldReward);
    }

    public void StealGold()
    {
        if (bank == null)
        {
            return;
        }
        bank.Withdraw(goldPenalty);
    }
}
