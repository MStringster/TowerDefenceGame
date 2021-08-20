using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("General Tower Settings")]
    [Tooltip("Cost to place Tower")]
    [SerializeField] int price = 50;
    [Tooltip("Time it takes to build the Tower")]
    [SerializeField] float buildDelay = 1.0f;

    void Start()
    {
        StartCoroutine(Build());
    }

    public bool CreateTower(Tower tower, Vector3 Position)
    {
        ManaBank bank = FindObjectOfType<ManaBank>();
        if(bank == null)
        {
            return false;
        }
        if (bank.CurrentBalance >= price)
        {
            Instantiate(tower.gameObject, Position, Quaternion.identity);
            bank.Withdraw(price);
            return true;
        }
        return false;
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

    }
}
