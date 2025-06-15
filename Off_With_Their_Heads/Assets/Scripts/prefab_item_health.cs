using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_item_health : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("player1") && collision.gameObject.CompareTag("player"))
        {
            var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
            manager_game_script.count_credit += 100;
            var prefab_player1_script = collision.gameObject.GetComponent<prefab_player1>();
            prefab_player1_script.health += 1;
            Destroy(gameObject);
        }
        if (collision.gameObject.name.Contains("player2") && collision.gameObject.CompareTag("player"))
        {
            var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
            manager_game_script.count_credit += 100;
            var prefab_player2_script = collision.gameObject.GetComponent<prefab_player2>();
            prefab_player2_script.health += 1;
            Destroy(gameObject);
        }
    }
}