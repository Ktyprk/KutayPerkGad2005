using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    public static Action<int> OnCoinValueChanged;
    public static Action<int> OnHealthValueChanged;

    public CharacterMovement cc;
    public bool firstlevelfinish = false;

    [Header("Settings")]
    [SerializeField] private int coinValue = 0;    
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth = 100;

    private void Awake()
    { Instance = this; }

    private void Start()
    { currentHealth = maxHealth; }

    public void CollectCoin()
    { 
        coinValue++;
        OnCoinValueChanged?.Invoke(coinValue);
    }

    public void Finished()
    {
        cc.speed = 0;
        StartCoroutine(FinishLine1());
    }

    public void CollectTrap()
    {
        int healhDecreaseValue = 10;
        currentHealth -= healhDecreaseValue;
        currentHealth = Mathf.Max(currentHealth, 0);
        OnHealthValueChanged?.Invoke(currentHealth);
    }

    public int GetMaxHealth()
    { return maxHealth; }

    public int GetCoinValue()
    { return coinValue; }

    private IEnumerator FinishLine1()
    {
        cc.transform.GetChild(1).Rotate(new Vector3(0, 180, 0));
        cc.GetComponent<Animator>().SetBool("Victory", true);
        yield return new WaitForSeconds(5.0f);

        if (firstlevelfinish == false)
        {
            SceneManager.LoadScene(1);       
        }
        
    }
}
