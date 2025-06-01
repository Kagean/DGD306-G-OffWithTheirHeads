using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class animation_player1 : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public int index;
    public List<string> data_p1 = new List<string>();
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p1 = manager_game_script.data_p1;
    }
    void Update()
    {
        var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
        if (prefab_player1_script.animation_flip)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false;
        }
        if (3 > prefab_player1_script.animation_change)
        {
            prefab_player1_script.animation_change += 1;
            if (index == 3)
            {
                animator.CrossFade("legs" + prefab_player1_script.animation_state, 0f);
            }
            else
            {
                animator.CrossFade(data_p1[index] + prefab_player1_script.animation_state, 0f);
            }
        }
    }
}