using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour, ICollectibles
{
    public Transform coinTransform; 
    public float rotationSpeed = 180.0f; 

    private void Start()
    {
        StartCoroutine(RotateCoinContinuously());
    }

    public void CollectItem()
    {
        CollectibleManager.Instance.CollectCoin();
    }

    private IEnumerator RotateCoinContinuously()
    {
        while (true)
        {
            coinTransform.DORotate(new Vector3(0, 360, 0), 1.0f, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
