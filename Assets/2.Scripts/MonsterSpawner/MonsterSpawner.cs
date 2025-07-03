using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpanwer : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private float startTime = 0f;
    [SerializeField] private float timer = 1f;

    public Transform parent;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), startTime, timer);
    }

    void Spawn()
    {
        Instantiate(zombiePrefab, transform.position, transform.rotation, parent);
    }
}
