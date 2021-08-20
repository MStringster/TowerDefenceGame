using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManaBank : MonoBehaviour
{
    [Header("Bank Settings")]
    [Tooltip("Balance player will start the game with")]
    [SerializeField] int startingBalance = 150;
    [Tooltip("Text Mesh Pro Text")]
    [SerializeField] TextMeshProUGUI displayBalance;

    int currentBalance = 0;
    public int CurrentBalance {get { return currentBalance; } }

    

    private void Awake()
    {
        currentBalance = startingBalance;
        updateDisplay();
    }
     
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        updateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        updateDisplay();
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }
    void updateDisplay()
    {
        displayBalance.text = $"Mana: {currentBalance}";
    }
    void ReloadScene()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.buildIndex);
    }
}
