using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_projectile_player2 : MonoBehaviour
{
    private float timer_destroy = 0;
    private float speed_movement = 12f;
    private int damage;
    private string direction;
    public Animator animator;
    public Collider2D collider;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriterenderer;
    public List<string> data_p2 = new List<string>();
    void Start()
    {
        if (GameObject.Find("prefab_player2(Clone)") != null)
        {
            animator = GetComponent<Animator>();
            collider = GetComponent<Collider2D>();
            rigidbody = GetComponent<Rigidbody2D>();
            spriterenderer = GetComponent<SpriteRenderer>();
            var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
            data_p2 = manager_game_script.data_p2;
            var prefab_player2_script = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
            if (data_p2[2].Contains("cannon"))
            {
                animator.CrossFade("projectile_player_cannonball", 0f);
                damage = 2;
            }
            else
            {
                animator.CrossFade("projectile_player_arrow", 0f);
                damage = 1;
            }
            if (prefab_player2_script.is_faced_up)
            {
                transform.position += new Vector3(0, 0.32f, 0);
                if (prefab_player2_script.animation_flip)
                {
                    spriterenderer.flipX = true;
                    transform.rotation = Quaternion.Euler(0, 0, -90f);
                }
                else
                {
                    spriterenderer.flipX = false;
                    transform.rotation = Quaternion.Euler(0, 0, 90f);
                }
            }
            else
            {
                if (prefab_player2_script.animation_flip)
                {
                    transform.position += new Vector3(-0.32f, 0, 0);
                    spriterenderer.flipX = true;
                    direction = "left";
                }
                else
                {
                    transform.position += new Vector3(0.32f, 0, 0);
                    spriterenderer.flipX = false;
                    direction = "right";
                }
            }
        }
    }
    void Update()
    {
        if (direction == "left")
        {
            rigidbody.velocity = Vector2.left * speed_movement;
        }
        else if (direction == "right")
        {
            rigidbody.velocity = Vector2.right * speed_movement;
        }
        else
        {
            rigidbody.velocity = Vector2.up * speed_movement;
        }
        if (timer_destroy >= 1f)
        {
            Projectile_Destroyed();
        }
        timer_destroy += Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("wall"))
        {
            Projectile_Destroyed();
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            Projectile_Destroyed();
            if (collision.gameObject.name == "boss_1")
            {
                var boss_1_script = collision.gameObject.GetComponent<boss_1>();
                boss_1_script.health -= damage;
            }
            else if (collision.gameObject.name == "boss_2")
            {
                var boss_2_script = collision.gameObject.GetComponent<boss_2>();
                boss_2_script.health -= damage;
            }
            else
            {
                var prefab_enemy_script = collision.gameObject.GetComponent<prefab_enemy>();
                prefab_enemy_script.health -= damage;
            }
        }
    }
    void Projectile_Destroyed()
    {
        if (data_p2[2].Contains("cannon"))
        {
            animator.CrossFade("projectile_player_cannonball_destroyed", 0f);
        }
        else
        {
            animator.CrossFade("projectile_player_arrow_destroyed", 0f);
        }
        speed_movement = 0;
        collider.enabled = false;
        Destroy(gameObject, 0.16f);
    }
}