using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_camera_movement_check : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        var camera_settings_script = GameObject.Find("camera_settings").GetComponent<camera_settings>();
        if (collision.gameObject.name.Contains("left"))
        {
            if (collision.gameObject.name.Contains("true"))
            {
                camera_settings_script.lock_direction_left = true;
            }
            else
            {
                camera_settings_script.lock_direction_left = false;
            }
        }
        if (collision.gameObject.name.Contains("right"))
        {
            if (collision.gameObject.name.Contains("true"))
            {
                camera_settings_script.lock_direction_right = true;
            }
            else
            {
                camera_settings_script.lock_direction_right = false;
            }
        }
        if (collision.gameObject.name.Contains("down"))
        {
            if (collision.gameObject.name.Contains("true"))
            {
                camera_settings_script.lock_direction_down = true;
            }
            else
            {
                camera_settings_script.lock_direction_down = false;
            }
        }
        if (collision.gameObject.name.Contains("up"))
        {
            if (collision.gameObject.name.Contains("true"))
            {
                camera_settings_script.lock_direction_up = true;
            }
            else
            {
                camera_settings_script.lock_direction_up = false;
            }
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            var prefab_enemy_script = collision.gameObject.GetComponent<prefab_enemy>();
            prefab_enemy_script.is_active = true;
        }
    }
}