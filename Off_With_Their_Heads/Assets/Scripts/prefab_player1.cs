using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class prefab_player1 : MonoBehaviour
{
    private bool is_ground = false;
    private bool lock_key = false;
    private float speed_attack;
    private float speed_invincible = 1f;
    private float speed_movement = 4f;
    private float timer_attack = 0;
    private float timer_invincible = 0;
    private int p1_horizontal;
    private int p1_vertical;
    public Collider2D collider;
    public GameObject prefab_player2;
    public GameObject prefab_player1_death;
    public GameObject prefab_projectile_player1;
    public Rigidbody2D rigidbody;
    public bool animation_flip = false;
    public bool has_head = false;
    public bool has_torso = false;
    public bool has_limbs = false;
    public bool is_faced_up = false;
    public bool is_invincible = false;
    public bool is_shadow = false;
    public int animation_change = 0;
    public int animation_change_hands = 1;
    public int health = 3;
    public string animation_state;
    public List<string> data_p1 = new List<string>();
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p1 = manager_game_script.data_p1;
        if (data_p1[2].Contains("cannon"))
        {
            speed_attack = 1f;
        }
        else
        {
            speed_attack = 0.5f;
        }
        Set_Stats(1);
        Set_Stats(0);
        animation_state = "_jump";
    }
    void Update()
    {
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        p1_horizontal = (int)Input.GetAxisRaw("p1_horizontal");
        p1_vertical = (int)Input.GetAxisRaw("p1_vertical");
        if ((Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W)) || p1_horizontal == 1)
        {
            rigidbody.velocity = new Vector2(-speed_movement, rigidbody.velocity.y);
            if (lock_key)
            {
                is_faced_up = false;
                lock_key = false;
                animation_flip = true;
                animation_change = 0;
                animation_change_hands = 1;
                animation_state = "_walk";
            }
        }
        else if ((Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W)) || p1_horizontal == -1)
        {
            rigidbody.velocity = new Vector2(speed_movement, rigidbody.velocity.y);
            if (lock_key)
            {
                is_faced_up = false;
                lock_key = false;
                animation_flip = false;
                animation_change = 0;
                animation_change_hands = 1;
                animation_state = "_walk";
            }
        }
        else if ((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || p1_vertical == 1)
        {
            if (lock_key)
            {
                is_faced_up = true;
                lock_key = false;
                animation_change = 0;
                animation_change_hands = 2;
                animation_state = "_idle";
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
            if (!lock_key)
            {
                lock_key = true;
                animation_change = 0;
                animation_state = "_idle";
            }
        }
        if (Input.GetKey(KeyCode.T) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            if (is_ground)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 8f);
            }
        }
        if (Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            if (timer_attack >= speed_attack)
            {
                Instantiate(prefab_projectile_player1, transform.position, transform.rotation);
                timer_attack = 0;
            }
        }
        if (!is_ground)
        {
            animation_change = 0;
            animation_state = "_jump";
        }
        if (is_invincible)
        {
            timer_invincible += Time.deltaTime;
            if (timer_invincible >= speed_invincible)
            {
                timer_invincible = 0;
                is_invincible = false;
            }
        }
        if (0 >= health)
        {
            if (manager_game_script.is_coop)
            {
                if (GameObject.Find("prefab_player2(Clone)") == null)
                {
                    manager_game_script.count_credit -= 1;
                    if (manager_game_script.count_credit == 0)
                    {
                        SceneManager.LoadScene("cutscene_lose");
                    }
                    health = 1;
                    Instantiate(prefab_player2, transform.position + new Vector3(0, 1.28f, 0), transform.rotation);
                    var prefab_player2_script = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
                    prefab_player2_script.is_invincible = true;
                    prefab_player2_script.health = 1;
                }
                else
                {
                    Instantiate(prefab_player1_death, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
            else
            {
                manager_game_script.count_credit -= 1;
                if (manager_game_script.count_credit == 0)
                {
                    SceneManager.LoadScene("cutscene_lose");
                }
                else
                {
                    is_invincible = true;
                    health = 1;
                }
            }
        }
        if (manager_game_script.is_coop)
        {
            if (GameObject.Find("prefab_player2(Clone)") == null)
            {
                if (has_head && has_torso && has_limbs)
                {
                    Instantiate(prefab_player2, transform.position + new Vector3(0, 1.28f, 0), transform.rotation);
                    var prefab_player2_script = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
                    prefab_player2_script.is_invincible = true;
                    prefab_player2_script.health = 1;
                    has_head = false;
                    has_torso = false;
                    has_limbs = false;
                }
            }
        }
        timer_attack += Time.deltaTime;
    }
    void Set_Stats(int index)
    {
        if (data_p1[index].Contains("dwarf"))
        {
            speed_invincible *= 1.5f;
            health += 1;
        }
        else if (data_p1[index].Contains("elf"))
        {
            speed_attack *= 0.75f;
        }
        else
        {
            speed_movement *= 1.5f;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            is_ground = true;
            is_shadow = true;
            if (Mathf.Abs(rigidbody.velocity.x) >= 0.4f)
            {
                animation_change = 0;
                animation_state = "_walk";
            }
            else
            {
                animation_change = 0;
                animation_state = "_idle";
            }
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            is_ground = true;
            is_shadow = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            is_ground = false;
            is_shadow = false;
        }
    }
}