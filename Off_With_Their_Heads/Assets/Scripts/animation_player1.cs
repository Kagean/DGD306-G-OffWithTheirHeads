using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class animation_player1 : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriterenderer;
    public bool animation_flip;
    public int animation_change;
    public string animation_state;
    public int index;
    public List<string> data_p1 = new List<string>();
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p1 = script_manager_game.data_p1;
        var script_prefab_player1 = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
        animation_flip = script_prefab_player1.animation_flip;
        animation_change = script_prefab_player1.animation_change;
        animation_state = script_prefab_player1.animation_state;
    }
    void Update()
    {
        var script_prefab_player1 = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
        animation_flip = script_prefab_player1.animation_flip;
        if (animation_flip)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false;
        }
        if (3 > animation_change)
        {
            script_prefab_player1.animation_change += 1;
            animation_change += 1;
            animator.CrossFade(data_p1[index] + animation_state, 0f);
        }
    }
}