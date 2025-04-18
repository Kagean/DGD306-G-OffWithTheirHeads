using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start_game : MonoBehaviour
{
    private bool is_nolock = true;
    private float timer = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (is_nolock)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject object_prefab_fade = GameObject.Find("prefab_fade");
                prefab_fade script_prefab_fade = object_prefab_fade.GetComponent<prefab_fade>();
                script_prefab_fade.fade_out = true;
            }
        }
    }
}