using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shadow_player2 : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
        if (prefab_player1_script.change_pos_shadow)
        {
            prefab_player1_script.change_pos_shadow = false;
        }
    }
}