using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_player2 : MonoBehaviour
{
    private float speed_attack;
    private float speed_movement = 8f;
    private float timer = 0;
    public int health = 3;
    public List<string> data_p2 = new List<string>();
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p2 = script_manager_game.data_p2;
        if (data_p2[2].Contains("cannon"))
        {
            speed_attack = 1000f;
        }
        else
        {
            speed_attack = 500f;
        }
        Set_Stats(1);
        Set_Stats(0);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= speed_attack)
        {
            timer = 0;
        }
    }
    void Set_Stats(int index)
    {
        if (data_p2[index].Contains("dwarf"))
        {
            health += 1;
        }
        else if (data_p2[index].Contains("elf"))
        {
            speed_attack /= 1.5f;
        }
        else
        {
            speed_movement += 4f;
        }
    }
}