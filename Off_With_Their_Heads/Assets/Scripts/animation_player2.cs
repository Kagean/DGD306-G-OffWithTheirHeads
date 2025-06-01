using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class animation_player2 : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriterenderer;
    public int index;
    public List<string> data_p2 = new List<string>();
    void Start()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p2 = manager_game_script.data_p2;
    }
    void Update()
    {
        var prefab_player2_script = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
        if (prefab_player2_script.animation_flip)
        {
            spriterenderer.flipX = true;
        }
        else
        {
            spriterenderer.flipX = false;
        }
        if (3 > prefab_player2_script.animation_change)
        {
            prefab_player2_script.animation_change += 1;
            if (index == 3)
            {
                animator.CrossFade("legs" + prefab_player2_script.animation_state, 0f);
            }
            else
            {
                animator.CrossFade(data_p2[index] + prefab_player2_script.animation_state, 0f);
            }
        }
    }
}