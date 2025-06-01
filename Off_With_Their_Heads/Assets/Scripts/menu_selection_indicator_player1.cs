using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_selection_indicator_player1 : MonoBehaviour
{
    private bool is_checked = true;
    public GameObject sprite_selection_indicator_bg_player1;
    public SpriteRenderer spriterenderer;
    public int index_col_indicator;
    public int index_row_indicator;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.enabled = false;
    }
    void Update()
    {
        if (is_checked)
        {
            var script_menu_selection_select = GameObject.Find("menu_selection_select").GetComponent<menu_selection_select>();
            if (index_col_indicator == script_menu_selection_select.index_col_p1 && index_row_indicator == script_menu_selection_select.index_row)
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
    void Instantiate_Indicator()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            is_checked = false;
            SpriteRenderer spriterenderer = GetComponent<SpriteRenderer>();
            spriterenderer.enabled = false;
            Instantiate(sprite_selection_indicator_bg_player1, transform.position, transform.rotation);
        }
    }
}