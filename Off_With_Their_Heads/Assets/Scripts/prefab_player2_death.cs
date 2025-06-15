using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_player2_death : MonoBehaviour
{
    private float speed_movement;
    public Animator animator;
    public Collider2D collider;
    public Rigidbody2D rigidbody;
    public float timer_death = 0;
    public string part;
    public List<string> data_p1 = new List<string>();
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p1 = manager_game_script.data_p1;
        if (part == "head")
        {
            animator.CrossFade(data_p1[0] + "_jump", 0f);
            speed_movement = -4f;
        }
        else if (part == "torso")
        {
            animator.CrossFade(data_p1[1] + "_jump", 0f);
            speed_movement = 0;
        }
        else
        {
            if (data_p1[2].Contains("cannon"))
            {
                animator.CrossFade("limbs_cannon", 0f);
            }
            else
            {
                animator.CrossFade("limbs_crossbow", 0f);
            }
            speed_movement = 4f;
        }
        rigidbody.velocity = new Vector2(speed_movement, 1f);
        gameObject.name = "prefab_player2_death_" + part;
    }
    void Update()
    {
        timer_death += Time.deltaTime;
        if (timer_death >= 4f)
        {
            Destroy(GameObject.Find("prefab_player2_death(Clone)"));
            Change_Has_Part(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("player1") && collision.gameObject.CompareTag("player"))
        {
            Change_Has_Part(true);
        }
    }
    void Change_Has_Part(bool has_part)
    {
        if (part == "head")
        {
            var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
            prefab_player1_script.has_head = has_part;
            if (transform.parent.childCount == 1)
            {
                Destroy(GameObject.Find("prefab_player2_death(Clone)"));
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (part == "torso")
        {
            var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
            prefab_player1_script.has_torso = has_part;
            if (transform.parent.childCount == 1)
            {
                Destroy(GameObject.Find("prefab_player2_death(Clone)"));
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
            prefab_player1_script.has_limbs = has_part;
            if (transform.parent.childCount == 1)
            {
                Destroy(GameObject.Find("prefab_player2_death(Clone)"));
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}