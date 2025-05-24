using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class animation_player1 : MonoBehaviour
{
    public int change_animation;
    public int index;
    public List<string> data_p1 = new List<string>();
    public string state_animation;
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p1 = script_manager_game.data_p1;
        var script_prefab_player1 = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
        change_animation = script_prefab_player1.change_animation;
        state_animation = script_prefab_player1.state_animation;
    }
    void Update()
    {
        if (change_animation != 3)
        {
            var script_prefab_player1 = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
            script_prefab_player1.change_animation += 1;
            change_animation += 1;
            Animator animator = GetComponent<Animator>();
            animator.CrossFade(data_p1[index] + state_animation, 0f);
        }
    }
}