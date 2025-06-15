using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class camera_settings : MonoBehaviour
{
    private GameObject prefab_player_lead;
    public bool lock_direction_left = true;
    public bool lock_direction_right = true;
    public bool lock_direction_down = true;
    public bool lock_direction_up = true;
    void Update()
    {
        if (GameObject.Find("prefab_player1(Clone)") != null)
        {
            prefab_player_lead = GameObject.Find("prefab_player1(Clone)");
        }
        else if (GameObject.Find("prefab_player2(Clone)") != null)
        {
            prefab_player_lead = GameObject.Find("prefab_player2(Clone)");
        }
        else
        {
            lock_direction_left = true;
            lock_direction_right = true;
            lock_direction_down = true;
            lock_direction_up = true;
        }
        if (!lock_direction_left)
        {
            if (transform.position.x > prefab_player_lead.transform.position.x)
            {
                transform.position = new Vector3(prefab_player_lead.transform.position.x, transform.position.y, transform.position.z);
            }
        }
        if (!lock_direction_right)
        {
            if (prefab_player_lead.transform.position.x > transform.position.x)
            {
                transform.position = new Vector3(prefab_player_lead.transform.position.x, transform.position.y, transform.position.z);
            }
        }
        if (!lock_direction_down)
        {
            if (transform.position.y > prefab_player_lead.transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, prefab_player_lead.transform.position.y + 1.5f, transform.position.z);
            }
        }
        if (!lock_direction_up)
        {
            if (prefab_player_lead.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, prefab_player_lead.transform.position.y + 1.5f, transform.position.z);
            }
        }
    }
}