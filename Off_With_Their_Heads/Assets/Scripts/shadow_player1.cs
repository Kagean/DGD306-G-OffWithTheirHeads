using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shadow_player1 : MonoBehaviour
{
    public SpriteRenderer spriterenderer;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
        if (prefab_player1_script.is_shadow)
        {
            spriterenderer.enabled = true;
        }
        else
        {
            spriterenderer.enabled = false;
        }
    }
}