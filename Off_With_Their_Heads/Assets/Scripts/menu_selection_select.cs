using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class menu_selection_select : MonoBehaviour
{
    private bool is_coop;
    private bool lock_p1_movement = false;
    private bool lock_p2_movement = false;
    private bool lock_p1_joystick = false;
    private bool lock_p2_joystick = false;
    private int count_enter = 0;
    private int index_head_p1 = 0;
    private int index_head_p2 = 0;
    private int p1_horizontal;
    private int p2_horizontal;
    public bool lock_select = true;
    public int index_col_p1 = 0;
    public int index_col_p2 = 0;
    public int index_row = 0;
    public List<string> data_p1 = new List<string>();
    public List<string> data_p2 = new List<string>();
    void Start()
    {
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        is_coop = manager_game_script.is_coop;
    }
    void Update()
    {
        p1_horizontal = (int)Input.GetAxisRaw("p1_horizontal");
        p2_horizontal = (int)Input.GetAxisRaw("p2_horizontal");
        if (is_coop)
        {
            Control_Selection(KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.Joystick1Button7, p1_horizontal, ref lock_p1_joystick, ref lock_p1_movement, ref index_head_p1, ref index_col_p1, ref data_p1);
            Control_Selection(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.Return, KeyCode.Joystick2Button7, p2_horizontal, ref lock_p2_joystick, ref lock_p2_movement, ref index_head_p2, ref index_col_p2, ref data_p2);
        }
        else
        {
            Control_Selection(KeyCode.A, KeyCode.D, KeyCode.Space, KeyCode.Joystick1Button7, p1_horizontal, ref lock_p1_joystick, ref lock_p1_movement, ref index_head_p1, ref index_col_p1, ref data_p1);
        }
        if (index_row > 2)
        {
            var prefab_fade_script = GameObject.Find("prefab_fade").GetComponent<prefab_fade>();
            prefab_fade_script.fade_out = true;
            var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
            manager_game_script.data_p1 = data_p1;
            manager_game_script.data_p2 = data_p2;
        }
    }
    void Control_Selection(KeyCode keyboard_left, KeyCode keyboard_right, KeyCode keyboard_select, KeyCode joystick_select, int p_horizontal, ref bool lock_p_joystick, ref bool lock_p_movement, ref int index_head_p, ref int index_col_p, ref List<string> data_p)
    {
        if (!lock_p_movement)
        {
            if (Input.GetKeyDown(keyboard_left) || (p_horizontal == 1 && !lock_p_joystick))
            {
                lock_p_joystick = true;
                index_col_p -= 1;
                Check_Index(ref index_head_p, ref index_col_p, -1);
            }
            else if (Input.GetKeyDown(keyboard_right) || (p_horizontal == -1 && !lock_p_joystick))
            {
                lock_p_joystick = true;
                index_col_p += 1;
                Check_Index(ref index_head_p, ref index_col_p, 1);
            }
            else if ((Input.GetKey(keyboard_select) || Input.GetKey(joystick_select)) && !lock_select)
            {
                lock_select = true;
                Write_Selection(ref index_col_p, ref data_p);
                Check_Lock(ref lock_p_movement, ref lock_p1_movement, ref lock_p2_movement, ref count_enter, ref index_head_p1, ref index_head_p2, ref index_col_p1, ref index_col_p2, ref index_row);
            }
            else if (p_horizontal == 0)
            {
                lock_p_joystick = false;
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
    void Check_Index(ref int index_head_p, ref int index_col_p, int offset)
    {
        Check_Head(ref index_head_p, ref index_col_p, offset);
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
        Check_Head(ref index_head_p, ref index_col_p, offset);
    }
    void Write_Selection(ref int index_col_p, ref List<string> data_p)
    {
        switch (index_row)
        {
            case 0:
                switch (index_col_p)
                {
                    case 0:
                        data_p.Add("heads_dwarf");
                        break;
                    case 1:
                        data_p.Add("heads_elf");
                        break;
                    case 2:
                        data_p.Add("heads_goblin");
                        break;
                }
                break;
            case 1:
                switch (index_col_p)
                {
                    case 0:
                        data_p.Add("torso_dwarf");
                        break;
                    case 1:
                        data_p.Add("torso_elf");
                        break;
                    case 2:
                        data_p.Add("torso_goblin");
                        break;
                }
                break;
            case 2:
                switch (index_col_p)
                {
                    case 0:
                        data_p.Add("hands_crossbow");
                        break;
                    case 1:
                        data_p.Add("hands_cannon");
                        break;
                }
                break;
        }
    }
    void Check_Lock(ref bool lock_p_movement, ref bool lock_p1_movement, ref bool lock_p2_movement, ref int count_enter, ref int index_head_p1, ref int index_head_p2, ref int index_col_p1, ref int index_col_p2, ref int index_row)
    {
        if (is_coop)
        {
            lock_p_movement = true;
            count_enter += 1;
            if (count_enter > 1)
            {
                lock_p1_movement = false;
                lock_p2_movement = false;
                count_enter = 0;
                index_head_p1 = index_col_p1;
                index_head_p2 = index_col_p2;
                index_row += 1;
                Check_Head(ref index_head_p1, ref index_col_p1, 1);
                Check_Head(ref index_head_p2, ref index_col_p2, 1);
                index_col_p1 = 0;
                index_col_p2 = 0;
                Check_Head(ref index_head_p1, ref index_col_p1, 1);
                Check_Head(ref index_head_p2, ref index_col_p2, 1);
            }
        }
        else
        {
            index_head_p1 = index_col_p1;
            index_row += 1;
            Check_Head(ref index_head_p1, ref index_col_p1, 1);
            index_col_p1 = 0;
            Check_Head(ref index_head_p1, ref index_col_p1, 1);
        }
    }
}