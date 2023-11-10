using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, ICollectibles
{
    public void CollectItem()
    {
        CollectibleManager.Instance.CollectTrap();
    }
}
