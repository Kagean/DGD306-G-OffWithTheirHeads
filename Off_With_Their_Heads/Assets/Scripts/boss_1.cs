using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class boss_1 : MonoBehaviour
{
    private bool lock_point = false;
    private bool is_running = false;
    private bool set = true;
    private float timer_phase = 0;
    public Animator animator;
    public Collider2D collider;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriterenderer;
    public bool is_active = false;
    public int health = 30;
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        collider.enabled = false;
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        spriterenderer.flipX = true;
        spriterenderer.enabled = false;
        animator.CrossFade("boss_1_jump", 0f);
    }
    void Update()
    {
        var camera_settings_script = GameObject.Find("camera_settings").GetComponent<camera_settings>();
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
        if (camera_settings_script.lock_direction_left && camera_settings_script.lock_direction_right && camera_settings_script.lock_direction_up && camera_settings_script.lock_direction_down)
        {
            is_active = true;
        }
        if (is_active)
        {
            if (set)
            {
                set = false;
                collider.enabled = true;
                rigidbody.bodyType = RigidbodyType2D.Dynamic;
                spriterenderer.enabled = true;
            }
            if (6f > timer_phase && timer_phase >= 4f)
            {
                is_running = true;
                if (is_running)
                {
                    animator.CrossFade("boss_1_run", 0f);
                    is_running = false;
                }
                rigidbody.velocity = new Vector2(-5.5f, rigidbody.velocity.y);
            }
            else if (8f > timer_phase && timer_phase >= 6f)
            {
                spriterenderer.flipX = false;
                rigidbody.velocity = new Vector2(5.5f, rigidbody.velocity.y);
            }
            else if (10f > timer_phase && timer_phase >= 8f)
            {
                spriterenderer.flipX = true;
                rigidbody.velocity = new Vector2(-5.5f, 2f);
            }
            else if (12f > timer_phase && timer_phase >= 10f)
            {
                spriterenderer.flipX = false;
                rigidbody.velocity = new Vector2(5.5f, 2f);
            }
            else if (timer_phase >= 12f)
            {
                rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                animator.CrossFade("boss_1_idle", 0f);
                timer_phase = 0;
            }
            timer_phase += Time.deltaTime;
        }
        if (0 >= health)
        {
            collider.enabled = false;
            rigidbody.gravityScale = 0;
            Destroy(gameObject, 0.58f);
            animator.CrossFade("boss_1_destroyed", 0f);
            var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
            if (!lock_point)
            {
                lock_point = true;
                manager_game_script.count_score += 5000;
                manager_game_script.count_score_total += manager_game_script.count_score;
            }
            var manager_level_script = GameObject.Find("manager_level").GetComponent<manager_level>();
            manager_level_script.lock_timer = true;
            var script_prefab_fade = GameObject.Find("prefab_fade (2)").GetComponent<prefab_fade>();
            script_prefab_fade.fade_out = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (12f > timer_phase && timer_phase >= 4f)
            {
                is_running = true;
                if (is_running)
                {
                    animator.CrossFade("boss_1_run", 0f);
                    is_running = false;
                }
            }
            else
            {
                animator.CrossFade("boss_1_idle", 0f);
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            animator.CrossFade("boss_1_jump", 0f);
        }
    }
}