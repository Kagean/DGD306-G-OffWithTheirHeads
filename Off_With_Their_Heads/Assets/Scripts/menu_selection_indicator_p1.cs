using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_selection_indicator_p1 : MonoBehaviour
{
    private bool is_checked = true;
    private int index_col_p1;
    private int index_row;
    public GameObject sprite_selection_indicator_bg_p1;
    public int index_col_indicator;
    public int index_row_indicator;
    void Start()
    {
        SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.enabled = false;
    }
    void Update()
    {
        if (is_checked)
        {
            var script_menu_selection_select = GameObject.Find("menu_selection_select").GetComponent<menu_selection_select>();
            index_col_p1 = script_menu_selection_select.index_col_p1;
            index_row = script_menu_selection_select.index_row;
            if (index_col_indicator == index_col_p1 && index_row_indicator == index_row)
            {
                SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
                spriterenderer.enabled = true;
                Instantiate_Indicator();
            }
            else
            {
                SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
                spriterenderer.enabled = false;
            }
        }
    }
    void Instantiate_Indicator()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            is_checked = false;
            Instantiate(sprite_selection_indicator_bg_p1, transform.position, Quaternion.identity);
        }
    }
}