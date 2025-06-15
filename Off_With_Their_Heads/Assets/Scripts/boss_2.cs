using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class boss_2 : MonoBehaviour
{
    private bool is_active = false;
    private float timer_phase_1 = 0;
    private float timer_phase_2 = 2f;
    public GameObject prefab_boss_2_projectile;
    public Animator animator;
    public Collider2D collider;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriterenderer;
    public int health = 30;
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        collider.enabled = false;
        spriterenderer.flipX = true;
        spriterenderer.enabled = false;
        animator.CrossFade("boss_1_idle", 0f);
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
            if (timer_phase_1 >= 4f)
            {
                Instantiate(prefab_boss_2_projectile, transform.position + new Vector3(0, 0.128f, 0), transform.rotation);
                timer_phase_1 = 0;
            }
            if (timer_phase_2 >= 4f)
            {
                Instantiate(prefab_boss_2_projectile, transform.position + new Vector3(0, -0.64f, 0), transform.rotation);
                timer_phase_1 = 0;
            }
            timer_phase_1 += Time.deltaTime;
            timer_phase_2 += Time.deltaTime;
        }
        if (0 >= health)
        {
            collider.enabled = false;
            Destroy(gameObject, 0.416f);
            animator.CrossFade("boss_2_destroyed", 0f);
            var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
            manager_game_script.count_score += 5000;
            manager_game_script.count_score_total += manager_game_script.count_score;
            var manager_level_script = GameObject.Find("manager_level").GetComponent<manager_level>();
            manager_level_script.lock_timer = true;
            var script_prefab_fade = GameObject.Find("prefab_fade (2)").GetComponent<prefab_fade>();
            script_prefab_fade.fade_out = true;
        }
    }
}