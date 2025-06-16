using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wall_boss : MonoBehaviour
{
    private bool lock_update = false;
    public Collider2D collider;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }
    void Update()
    {
        var camera_settings_script = GameObject.Find("camera_settings").GetComponent<camera_settings>();
        if (!lock_update && camera_settings_script.lock_direction_left && camera_settings_script.lock_direction_right && camera_settings_script.lock_direction_up && camera_settings_script.lock_direction_down)
        {
            lock_update = true;
            collider.enabled = true;
            if (GameObject.Find("prefab_player1(Clone)") != null && GameObject.Find("prefab_player2(Clone)") != null)
            {
                var prefab_player1_ref = GameObject.Find("prefab_player1(Clone)");
                var prefab_player2_ref = GameObject.Find("prefab_player2(Clone)");
                prefab_player2_ref.transform.position = new Vector3(prefab_player1_ref.transform.position.x, prefab_player1_ref.transform.position.y + 1.28f, prefab_player1_ref.transform.position.z);
                var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
                var prefab_player2_script = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
                prefab_player1_script.is_invincible = true;
                prefab_player2_script.is_invincible = true;
            }
        }
    }
}