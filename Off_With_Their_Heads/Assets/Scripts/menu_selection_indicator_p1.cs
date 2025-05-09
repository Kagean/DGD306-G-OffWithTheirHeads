using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_selection_indicator_p1 : MonoBehaviour
{
    private int index_col_p1;
    private int index_row;
    public int index_col_indicator;
    public int index_row_indicator;
    void Start()
    {
        var script_menu_selection_select = GameObject.Find("menu_selection_select").GetComponent<menu_selection_select>();
        index_col_p1 = script_menu_selection_select.index_col_p1;
        index_row = script_menu_selection_select.index_row;
    }
    void Update()
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