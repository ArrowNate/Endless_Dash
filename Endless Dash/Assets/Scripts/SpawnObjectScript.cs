using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * (speed + gm.speedMultiplier);
    }
}