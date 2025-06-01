using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_selection_indicator_player2 : MonoBehaviour
{
    private bool is_checked = true;
    private bool is_coop;
    public GameObject sprite_selection_indicator_bg_player2;
    public SpriteRenderer spriterenderer;
    public int index_col_indicator;
    public int index_row_indicator;
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        is_coop = script_manager_game.is_coop;
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.enabled = false;
    }
    void Update()
    {
        if (is_checked)
        {
            var script_menu_selection_select = GameObject.Find("menu_selection_select").GetComponent<menu_selection_select>();
            if (is_coop)
            {
                if (index_col_indicator == script_menu_selection_select.index_col_p2 && index_row_indicator == script_menu_selection_select.index_row)
                {
                    spriterenderer = GetComponent<SpriteRenderer>();
                    spriterenderer.enabled = true;
                    Instantiate_Indicator();
                }
                else
                {
                    spriterenderer = GetComponent<SpriteRenderer>();
                    spriterenderer.enabled = false;
                }
            }
        }
    }
    void Instantiate_Indicator()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            is_checked = false;
            SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
            spriterenderer.enabled = false;
            Instantiate(sprite_selection_indicator_bg_player2, transform.position, transform.rotation);
        }
    }
}