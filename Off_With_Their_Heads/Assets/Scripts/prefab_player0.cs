using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<<< Updated upstream:Off_With_Their_Heads/Assets/Scripts/spawn_player.cs
public class spawn_player : MonoBehaviour
========
public class prefab_player0 : MonoBehaviour
>>>>>>>> Stashed changes:Off_With_Their_Heads/Assets/Scripts/prefab_player0.cs
{
    private bool is_coop;
    public GameObject prefab_player1;
    public GameObject prefab_player2;
    public float offset_x_p1 = 0;
    public float offset_y_p1 = 0;
    public float offset_x_p2 = 0;
    public float offset_y_p2 = 0;
    void Start()
    {
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        is_coop = manager_game_script.is_coop;
        if (is_coop)
        {
            Instantiate(prefab_player1, transform.position + new Vector3(offset_x_p1, offset_y_p1, 0), transform.rotation);
            Instantiate(prefab_player2, transform.position + new Vector3(-offset_x_p2, offset_y_p2, 0), transform.rotation);
        }
        else
        {
            Instantiate(prefab_player1, transform.position, transform.rotation);
        }
    }
}