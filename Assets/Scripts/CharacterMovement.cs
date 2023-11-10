using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class CharacterMovement : MonoBehaviour
{
    public float speed = 0;
    public GameObject player;
    public bool tapToStart = false;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (tapToStart == true)
        {
            transform.Translate(Vector3.forward * speed);
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (player.transform.localPosition.x > -2.5f)
            {
                player.transform.DOLocalMoveX(player.transform.position.x - 2, 0.5f);
                player.GetComponent<Animator>().SetTrigger("RunLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (player.transform.localPosition.x < 2.5f)
            {
                player.transform.DOLocalMoveX(player.transform.position.x + 2, 0.5f);
                player.GetComponent<Animator>().SetTrigger("RunRight");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectibles collectible = other.GetComponent<ICollectibles>();

        if (collectible != null)
        {
            collectible.CollectItem();
            Destroy(other.gameObject);
        }

       
    }
}
