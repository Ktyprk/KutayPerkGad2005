using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public TMP_Text coinText;
    [SerializeField] private Image healthBarImage;
    public CharacterMovement player;

    public GameObject StartButton;
    // Start is called before the first frame update
    void Start()
    {
        CollectibleManager.OnCoinValueChanged += CollectibleManager_OnCoinValueChanged;
        UpdateCoinUI(CollectibleManager.Instance.GetCoinValue());
        CollectibleManager.OnHealthValueChanged += CollectibleManager_OnHealthValueChanged;
        UpdateUI(CollectibleManager.Instance.GetMaxHealth());

    }

    private void CollectibleManager_OnHealthValueChanged(int health)
    {
        UpdateUI(health);
    }

    private void UpdateUI(int health)
    {
        float animationDuration = 0.5f;
        int maxHelath = CollectibleManager.Instance.GetMaxHealth();
        healthBarImage.DOFillAmount((float)health / maxHelath, animationDuration);
    }

    private void CollectibleManager_OnCoinValueChanged(int coinValue)
    {
        UpdateCoinUI(coinValue);
    }

    private void UpdateCoinUI(int coinValue)
    {
        coinText.text = coinValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        player.GetComponent<Animator>().SetBool("Running", true);
        player.tapToStart = true;
        player.transform.GetChild(1).Rotate(new Vector3(0, 180, 0));
        StartButton.SetActive(false);
    }
}
