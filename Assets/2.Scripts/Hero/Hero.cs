using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAI : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float remainingDuration;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = transform.position;
            pos.z = -1f;
            Instantiate(bulletPrefab, pos, transform.rotation);
            animator.Play("Fire");
        }
    }
}
