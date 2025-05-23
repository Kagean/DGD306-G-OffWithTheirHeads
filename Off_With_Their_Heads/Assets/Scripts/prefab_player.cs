using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_player : MonoBehaviour
{
    private bool is_coop;
    public GameObject prefab_player1;
    public GameObject prefab_player2;
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        is_coop = script_manager_game.is_coop;
        if (is_coop)
        {
            Instantiate(prefab_player1, transform.position + new Vector3(0.64f, 0, 0), transform.rotation);
            Instantiate(prefab_player2, transform.position + new Vector3(-0.64f, 0, 0), transform.rotation);
        }
        else
        {
            Instantiate(prefab_player1, transform.position, transform.rotation);
        }
    }
}