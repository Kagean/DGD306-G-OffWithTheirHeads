using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_selection_select : MonoBehaviour
{
    private bool is_coop;
    private bool lock_p1 = false;
    private bool lock_p2 = false;
    private int count_enter = 0;
    private int index_head_p1 = 0;
    private int index_head_p2 = 0;
    public int index_col_p1 = 0;
    public int index_col_p2 = 0;
    public int index_row = 0;
    public List<string> data_p1 = new List<string>();
    public List<string> data_p2 = new List<string>();
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        is_coop = script_manager_game.is_coop;
    }
    void Update()
    {
        if (is_coop)
        {
            Control_Selection(KeyCode.A, KeyCode.D, KeyCode.Space, ref lock_p1, ref index_head_p1, ref index_col_p1, ref data_p1);
            Control_Selection(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Return, ref lock_p2, ref index_head_p2, ref index_col_p2, ref data_p2);
        }
        else
        {
            Control_Selection(KeyCode.A, KeyCode.D, KeyCode.Space, ref lock_p1, ref index_head_p1, ref index_col_p1, ref data_p1);
        }
        if (index_row > 2)
        {
            var script_prefab_fade = GameObject.Find("prefab_fade").GetComponent<prefab_fade>();
            script_prefab_fade.fade_out = true;
            var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
            script_manager_game.data_p1 = data_p1;
            script_manager_game.data_p2 = data_p2;
        }
    }
    void Control_Selection(KeyCode left, KeyCode right, KeyCode select, ref bool lock_p, ref int index_head_p, ref int index_col_p, ref List<string> data_p)
    {
        if (!lock_p)
        {
            if (Input.GetKeyDown(left))
            {
                index_col_p -= 1;
                Check_Head(ref index_head_p, ref index_col_p, -1);
                Check_Index(ref index_col_p);
                Check_Head(ref index_head_p, ref index_col_p, -1);
            }
            else if (Input.GetKeyDown(right))
            {
                index_col_p += 1;
                Check_Head(ref index_head_p, ref index_col_p, 1);
                Check_Index(ref index_col_p);
                Check_Head(ref index_head_p, ref index_col_p, 1);
            }
            else if (Input.GetKeyDown(select))
            {
                Write_Selection(ref index_col_p, ref data_p);
                Check_Lock(ref lock_p, ref lock_p1, ref lock_p2, ref count_enter, ref index_head_p1, ref index_head_p2, ref index_col_p1, ref index_col_p2, ref index_row);
            }
        }
    }
    void Check_Head(ref int index_head_p, ref int index_col_p, int offset)
    {
        if (index_row == 1)
        {
            if (index_head_p == index_col_p)
            {
                index_col_p += offset;
            }
        }
    }
    void Check_Index(ref int index_col_p)
    {
        if (2 > index_row)
        {
            if (index_col_p > 2)
            {
                index_col_p = 0;
            }
            else if(0 > index_col_p)
            {
                index_col_p = 2;
            }
        }
        else
        {
            if (index_col_p > 1)
            {
                index_col_p = 0;
            }
            else if (0 > index_col_p)
            {
                index_col_p = 1;
            }
        }
    }
    void Write_Selection(ref int index_col_p, ref List<string> data_p)
    {
        switch (index_row)
        {
            case 0:
                switch (index_col_p)
                {
                    case 0:
                        data_p.Add("head_elf");
                        break;
                    case 1:
                        data_p.Add("head_dwarf");
                        break;
                    case 2:
                        data_p.Add("head_goblin");
                        break;
                }
                break;
            case 1:
                switch (index_col_p)
                {
                    case 0:
                        data_p.Add("body_elf");
                        break;
                    case 1:
                        data_p.Add("body_dwarf");
                        break;
                    case 2:
                        data_p.Add("body_goblin");
                        break;
                }
                break;
            case 2:
                switch (index_col_p)
                {
                    case 0:
                        data_p.Add("weapon_crossbow");
                        break;
                    case 1:
                        data_p.Add("weapon_cannon");
                        break;
                }
                break;
        }
    }
    void Check_Lock(ref bool lock_p, ref bool lock_p1, ref bool lock_p2, ref int count_enter, ref int index_head_p1, ref int index_head_p2, ref int index_col_p1, ref int index_col_p2, ref int index_row)
    {
        if (is_coop)
        {
            lock_p = true;
            count_enter += 1;
            if (count_enter > 1)
            {
                lock_p1 = false;
                lock_p2 = false;
                count_enter = 0;
                index_head_p1 = index_col_p1;
                index_head_p2 = index_col_p2;
                index_col_p1 = 0;
                index_col_p2 = 0;
                index_row += 1;
                Check_Head(ref index_head_p1, ref index_col_p1, 1);
                Check_Head(ref index_head_p2, ref index_col_p2, 1);
            }
        }
        else
        {
            index_col_p1 = 0;
            index_row += 1;
            Check_Head(ref index_head_p1, ref index_col_p1, 1);
        }
    }
}