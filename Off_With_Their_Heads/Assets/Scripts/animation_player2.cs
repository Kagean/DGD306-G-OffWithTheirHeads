using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class animation_player2 : MonoBehaviour
{
    public int index;
    public List<string> data_p2 = new List<string>();
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p2 = script_manager_game.data_p2;
        Animator animator = GetComponent<Animator>();
        animator.CrossFade(data_p2[index] + "_idle", 0f);
    }
    void Update()
    {
        
    }
}