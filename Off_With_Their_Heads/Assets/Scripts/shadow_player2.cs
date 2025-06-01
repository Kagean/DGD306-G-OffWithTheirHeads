using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shadow_player2 : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        var prefab_player2_script = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
        if (prefab_player2_script.is_shadow)
        {
            spriterenderer.enabled = true;
        }
        else
        {
            spriterenderer.enabled = false;
        }
    }
}