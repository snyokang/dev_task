using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    public float lifetime = 5f;

    private Rigidbody2D rb;
    private float life = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        Vector2 direction = (mousePos - transform.position).normalized;

        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
        if (life > lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Monster")
        {
            Destroy(other.gameObject);
        }
    }
}
