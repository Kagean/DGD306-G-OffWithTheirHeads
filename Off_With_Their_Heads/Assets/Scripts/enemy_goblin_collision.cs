using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemy_goblin_collision : MonoBehaviour
{
    public bool is_active = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (is_active)
        {
            if (collision.gameObject.name.Contains("player1") && collision.gameObject.CompareTag("player"))
            {
                var prefab_player1_script = collision.gameObject.GetComponent<prefab_player1>();
                if (!prefab_player1_script.is_invincible)
                {
                    prefab_player1_script.health -= 1;
                    prefab_player1_script.is_invincible = true;
                }
            }
            if (collision.gameObject.name.Contains("player2") && collision.gameObject.CompareTag("player"))
            {
                var prefab_player2_script = collision.gameObject.GetComponent<prefab_player2>();
                if (!prefab_player2_script.is_invincible)
                {
                    prefab_player2_script.health -= 1;
                    prefab_player2_script.is_invincible = true;
                }
            }
        }
    }
}