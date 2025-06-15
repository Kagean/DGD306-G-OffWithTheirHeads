using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_projectile_enemy_arrow_left : MonoBehaviour
{
    private float speed_movement = 12f;
    public Animator animator;
    public Collider2D collider;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriterenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        transform.position += new Vector3(-0.32f, 0, 0);
        spriterenderer.flipX = true;
        animator.CrossFade("projectile_enemy_arrow", 0f);
    }
    void Update()
    {
        rigidbody.velocity = Vector2.left * speed_movement;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
        {
            Projectile_Destroyed();
        }
        if (collision.gameObject.name.Contains("player1") && collision.gameObject.CompareTag("player"))
        {
            Projectile_Destroyed();
            var prefab_player1_script = collision.gameObject.GetComponent<prefab_player1>();
            if (!prefab_player1_script.is_invincible)
            {
                prefab_player1_script.health -= 1;
                prefab_player1_script.is_invincible = true;
            }
        }
        if (collision.gameObject.name.Contains("player2") && collision.gameObject.CompareTag("player"))
        {
            Projectile_Destroyed();
            var prefab_player2_script = collision.gameObject.GetComponent<prefab_player2>();
            if (!prefab_player2_script.is_invincible)
            {
                prefab_player2_script.health -= 1;
                prefab_player2_script.is_invincible = true;
            }
        }
    }
    void Projectile_Destroyed()
    {
        animator.CrossFade("projectile_enemy_arrow_destroyed", 0f);
        speed_movement = 0;
        collider.enabled = false;
        Destroy(gameObject, 0.16f);
    }
}