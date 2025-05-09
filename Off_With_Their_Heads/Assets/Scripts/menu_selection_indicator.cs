using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_selection_indicator : MonoBehaviour
{
    private bool is_coop;
    private int index_col_p1;
    private int index_col_p2;
    private int index_row;
    public bool is_p2_indicator;
    public int index_col_indicator;
    public int index_row_indicator;
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        is_coop = script_manager_game.is_coop;
        var script_menu_selection_select = GameObject.Find("menu_selection_select").GetComponent<menu_selection_select>();
        index_col_p1 = script_menu_selection_select.index_col_p1;
        index_col_p2 = script_menu_selection_select.index_col_p2;
        index_row = script_menu_selection_select.index_row;
    }
    void Update()
    {
        if (is_p2_indicator)
        {
            if (is_coop)
            {
                if (index_col_indicator == index_col_p2 && index_row_indicator == index_row)
                {
                    SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
                    spriterenderer.enabled = true;
                }
                else
                {
                    SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
                    spriterenderer.enabled = false;
                }
            }
        }
        else
        {
            if (index_col_indicator == index_col_p1 && index_row_indicator == index_row)
            {
                SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
                spriterenderer.enabled = true;
            }
            else
            {
                SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
                spriterenderer.enabled = false;
            }
        }
    }
}