using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_player1 : MonoBehaviour
{
    private bool lock_key = false;
    private bool is_ground = false;
    private float speed_attack;
    private float speed_movement = 4f;
    private float timer_attack = 0;
    public Collider2D collider;
    public Rigidbody2D rigidbody;
    public bool animation_flip = false;
    public bool change_pos_shadow = false;
    public int animation_change = 0;
    public string animation_state;
    public int health = 3;
    public List<string> data_p1 = new List<string>();
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p1 = manager_game_script.data_p1;
        if (data_p1[2].Contains("cannon"))
        {
            speed_attack = 1000f;
        }
        else
        {
            speed_attack = 500f;
        }
        Set_Stats(1);
        Set_Stats(0);
        animation_state = "_jump";
    }
    void Update()
    {
        float joystick1_x = Input.GetAxisRaw("joystick1_x");
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || -0.5f > joystick1_x)
        {
            rigidbody.velocity = new Vector2(-speed_movement, rigidbody.velocity.y);
            if (lock_key)
            {
                lock_key = false;
                animation_flip = true;
                animation_change = 0;
                animation_state = "_walk";
            }
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) || joystick1_x > 0.5f)
        {
            rigidbody.velocity = new Vector2(speed_movement, rigidbody.velocity.y);
            if (lock_key || Input.GetKey(KeyCode.A))
            {
                lock_key = false;
                animation_flip = false;
                animation_change = 0;
                animation_state = "_walk";
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
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.Joystick1Button1))
        {
            if (is_ground)
            {
                rigidbody.velocity = Vector2.up * 8f;
            }
        }
        if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            if (timer_attack >= speed_attack)
            {
                timer_attack = 0;
            }
        }
        if (!is_ground)
        {
            animation_change = 0;
            animation_state = "_jump";
        }
        timer_attack += Time.deltaTime;
    }
    void Set_Stats(int index)
    {
        if (data_p1[index].Contains("dwarf"))
        {
            health += 1;
        }
        else if (data_p1[index].Contains("elf"))
        {
            speed_attack /= 1.5f;
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
            change_pos_shadow = true;
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
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            is_ground = false;
        }
    }
}