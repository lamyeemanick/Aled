using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    // public RectTransform transform;
    public Animator animator;
    private Vector3 direction;
    private Vector3 reverse;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        direction.x = 3;
        direction.y = 3;
        direction.z = 0;
        reverse = -direction;
        reverse.y = 3;
    }

    // Update is called once per frame // Inputs
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
            animator.SetBool("PlayerRun", true);
        else
            animator.SetBool("PlayerRun", false);
        if (movement.x < 0)
            transform.localScale = reverse;
        else if (movement.x > 0)
            transform.localScale = direction;
    }

    // Movements
    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}