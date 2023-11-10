using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour, ICollectibles
{
    public void CollectItem()
    {
        CollectibleManager.Instance.Finished();
    }
}
