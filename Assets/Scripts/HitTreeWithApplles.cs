using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTreeWithApplles : MonoBehaviour
{
    Animator animator;
    public int treeHp = 3;
    public Player player;
    public float rage = 1.5f;
    float distance;
    public GameObject applePrefab; // Префаб яблука

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckForHit();
    }

    void CheckForHit()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (Input.GetKeyDown(KeyCode.Q) && rage >= distance && treeHp >= 1)
        {
            treeHp--;
            animator.SetTrigger("Hit_tree");
            StartCoroutine(SpawnApple());
        }

        if (treeHp < 1)
        {
            animator.SetTrigger("Falled_tree");
        }
    }

    IEnumerator SpawnApple()
    {
        yield return new WaitForSeconds(2);
        Instantiate(applePrefab);
    }
}

