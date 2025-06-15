using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class animation_hands_player1 : MonoBehaviour
{
    private float rotation;
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public List<string> data_p1 = new List<string>();
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p1 = manager_game_script.data_p1;
<<<<<<< Updated upstream
        animator.CrossFade(data_p1[2], 0f);
=======
>>>>>>> Stashed changes
    }
    void Update()
    {
        var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
<<<<<<< Updated upstream
        if (prefab_player1_script.is_invincible)
        {
            Color color = spriterenderer.color;
            color.a = 0.5f;
            spriterenderer.color = color;
        }
        else
        {
            Color color = spriterenderer.color;
            color.a = 1f;
            spriterenderer.color = color;
        }
=======
>>>>>>> Stashed changes
        if (prefab_player1_script.animation_flip)
        {
            spriterenderer.flipX = true;
            rotation = -90f;
        }
        else
        {
            spriterenderer.flipX = false;
            rotation = 90f;
        }
        if (prefab_player1_script.animation_change_hands != 0)
        {
<<<<<<< Updated upstream
            if (prefab_player1_script.animation_change_hands == 1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, rotation);
            }
            animator.CrossFade(data_p1[2], 0f);
            prefab_player1_script.animation_change_hands = 0;
=======
            animator.CrossFade(prefab_player1_script.data_p1[2], 0f);
            prefab_player1_script.animation_change_hands = 0;
            if (prefab_player1_script.is_looking_up)
            {
                transform.rotation = Quaternion.Euler(0, 0, rotation);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
>>>>>>> Stashed changes
        }
    }
}