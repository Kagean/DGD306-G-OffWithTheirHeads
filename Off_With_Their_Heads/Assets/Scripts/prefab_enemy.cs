using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_enemy : MonoBehaviour
{
    private GameObject prefab_projectile_enemy;
    private bool lock_attack;
    private bool lock_movement;
    private bool lock_update = false;
    private float speed_attack;
    private float speed_movement;
    private float timer_attack = 0;
    public Animator animator;
    public Collider2D collider;
    public GameObject prefab_projectile_enemy_arrow_left;
    public GameObject prefab_projectile_enemy_arrow_right;
    public GameObject prefab_projectile_enemy_cannonball_left;
    public GameObject prefab_projectile_enemy_cannonball_right;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriterenderer;
    public bool is_active = false;
    public bool is_dwarf_destroyed = false;
    public bool is_faced_left;
    public int health;
    public string enemy;
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.enabled = false;
    }
    void Update()
    {
        if (GameObject.Find("prefab_player1(Clone)") != null)
        {
            var prefab_player1_collider = GameObject.Find("prefab_player1(Clone)").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player1_collider);
        }
        if (GameObject.Find("prefab_player2(Clone)") != null)
        {
            var prefab_player2_collider = GameObject.Find("prefab_player2(Clone)").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player2_collider);
        }
        if (GameObject.Find("prefab_player1_death_head") != null)
        {
            var prefab_player1_death_head_collider = GameObject.Find("prefab_player1_death_head").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player1_death_head_collider);
        }
        if (GameObject.Find("prefab_player1_death_torso") != null)
        {
            var prefab_player1_death_torso_collider = GameObject.Find("prefab_player1_death_torso").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player1_death_torso_collider);
        }
        if (GameObject.Find("prefab_player1_death_limbs") != null)
        {
            var prefab_player1_death_limbs_collider = GameObject.Find("prefab_player1_death_limbs").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player1_death_limbs_collider);
        }
        if (GameObject.Find("prefab_player2_death_head") != null)
        {
            var prefab_player2_death_head_collider = GameObject.Find("prefab_player2_death_head").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player2_death_head_collider);
        }
        if (GameObject.Find("prefab_player2_death_torso") != null)
        {
            var prefab_player2_death_torso_collider = GameObject.Find("prefab_player2_death_torso").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player2_death_torso_collider);
        }
        if (GameObject.Find("prefab_player2_death_limbs") != null)
        {
            var prefab_player2_death_limbs_collider = GameObject.Find("prefab_player2_death_limbs").GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(collider, prefab_player2_death_limbs_collider);
        }
        if (is_active)
        {
            if (!lock_update)
            {
                lock_update = true;
                collider.isTrigger = false;
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
                spriterenderer.enabled = true;
                if (enemy == "dwarf")
                {
                    rigidbody.gravityScale = 0.02f;
                    lock_attack = false;
                    lock_movement = true;
                    speed_attack = 1f;
                    health = 7;
                    animator.CrossFade("enemy_" + enemy, 0f);
                    if (is_faced_left)
                    {
                        rigidbody.velocity = new Vector2(-4f, -1f);
                        prefab_projectile_enemy = prefab_projectile_enemy_cannonball_left;
                    }
                    else
                    {
                        rigidbody.velocity = new Vector2(4f, -1f);
                        prefab_projectile_enemy = prefab_projectile_enemy_cannonball_right;
                    }
                }
                else if (enemy == "elf")
                {
                    rigidbody.gravityScale = 2f;
                    lock_attack = false;
                    lock_movement = true;
                    speed_attack = 0.75f;
                    health = 5;
                    animator.CrossFade("enemy_" + enemy, 0f);
                    if (is_faced_left)
                    {
                        rigidbody.velocity = new Vector2(-4f, rigidbody.velocity.y);
                        prefab_projectile_enemy = prefab_projectile_enemy_arrow_left;
                    }
                    else
                    {
                        rigidbody.velocity = new Vector2(4f, rigidbody.velocity.y);
                        prefab_projectile_enemy = prefab_projectile_enemy_arrow_right;
                    }
                }
                else
                {
                    rigidbody.gravityScale = 2f;
                    lock_attack = true;
                    lock_movement = false;
                    health = 5;
                    animator.CrossFade("enemy_" + enemy + "_jump", 0f);
                    var enemy_goblin_collision_script = GetComponentInChildren<enemy_goblin_collision>();
                    enemy_goblin_collision_script.is_active = true;
                    if (is_faced_left)
                    {
                        spriterenderer.flipX = true;
                        speed_movement = -6f;
                    }
                    else
                    {
                        speed_movement = 6f;
                    }
                }
            }
            if ((timer_attack >= speed_attack) && !lock_attack)
            {
                Instantiate(prefab_projectile_enemy, transform.position, transform.rotation);
                timer_attack = 0;
            }
            if (!lock_movement)
            {
                rigidbody.velocity = new Vector2(speed_movement, rigidbody.velocity.y);
            }
            else
            {
                timer_attack += Time.deltaTime;
            }
            if (0 >= health)
            {
                var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
                manager_game_script.count_credit += 500;
                if (enemy == "dwarf")
                {
                    lock_attack = true;
                    rigidbody.gravityScale = 2f;
                    animator.CrossFade("enemy_" + enemy + "_fall", 0f);
                    if (is_dwarf_destroyed)
                    {
                        is_active = false;
                        collider.enabled = false;
                        Destroy(gameObject, 0.16f);
                        animator.CrossFade("enemy_" + enemy + "_destroyed", 0f);
                    }
                }
                else
                {
                    is_active = false;
                    collider.enabled = false;
                    Destroy(gameObject, 0.16f);
                    animator.CrossFade("enemy_" + enemy + "_destroyed", 0f);
                }
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && enemy == "dwarf")
        {
            is_dwarf_destroyed = true;
            health = 0;
        }
        else if (collision.gameObject.CompareTag("ground") && enemy == "goblin")
        {
            animator.CrossFade("enemy_" + enemy, 0f);
        }
        else if (collision.gameObject.CompareTag("wall") && enemy == "goblin")
        {
            if (speed_movement == 6f)
            {
                spriterenderer.flipX = true;
                speed_movement = -6f;
            }
            else
            {
                spriterenderer.flipX = false;
                speed_movement = 6f;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && enemy == "goblin")
        {
            animator.CrossFade("enemy_" + enemy + "_jump", 0f);
        }
    }
}