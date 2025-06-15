using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class prefab_ui : MonoBehaviour
{
    private bool lock_animation = false;
    private float sum_float = 0;
    private int sum_int = 0;
    public string element;
    public List<string> data_p1 = new List<string>();
    public List<string> data_p2 = new List<string>();
    void Update()
    {
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        var manager_level_script = GameObject.Find("manager_level").GetComponent<manager_level>();
        var prefab_player1_script = GameObject.Find("prefab_player1(Clone)").GetComponent<prefab_player1>();
        var prefab_player2_script = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
        var prefab_player1_death_head_script = GameObject.Find("prefab_player1_death_head").GetComponent<prefab_player1_death>();
        var prefab_player1_death_torso_script = GameObject.Find("prefab_player1_death_torso").GetComponent<prefab_player1_death>();
        var prefab_player1_death_limbs_script = GameObject.Find("prefab_player1_death_limbs").GetComponent<prefab_player1_death>();
        var prefab_player2_death_head_script = GameObject.Find("prefab_player2_death_head").GetComponent<prefab_player2_death>();
        var prefab_player2_death_torso_script = GameObject.Find("prefab_player2_death_torso").GetComponent<prefab_player2_death>();
        var prefab_player2_death_limbs_script = GameObject.Find("prefab_player2_death_limbs").GetComponent<prefab_player2_death>();
        data_p1 = manager_game_script.data_p1;
        data_p2 = manager_game_script.data_p2;
        switch (element)
        {
            case "ui":
                if (manager_game_script.is_coop)
                {
                    if (!lock_animation)
                    {
                        lock_animation = true;
                        Animator animator = GetComponent<Animator>();
                        animator.CrossFade("ui_p1", 0f);
                    }
                }
                else
                {
                    if (!lock_animation)
                    {
                        lock_animation = true;
                        Animator animator = GetComponent<Animator>();
                        animator.CrossFade("ui_p2", 0f);
                    }
                }
                break;
            case "ui_credit":
                if (!lock_animation)
                {
                    lock_animation = true;
                    Animator animator = GetComponent<Animator>();
                    animator.CrossFade("ui_credit", 0f);
                }
                break;
            case "credit":
                GetComponent<TMPro.TextMeshProUGUI>().text = manager_game_script.count_credit.ToString();
                break;
            case "score":
                GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + manager_game_script.count_score.ToString();
                break;
            case "total":
                GetComponent<TMPro.TextMeshProUGUI>().text = "Total Score: " + manager_game_script.count_score_total.ToString();
                break;
            case "time":
                sum_float = manager_level_script.timer_level_limit - manager_level_script.timer_level;
                sum_int = (int)sum_float;
                GetComponent<TMPro.TextMeshProUGUI>().text = sum_int.ToString();
                break;
            case "health_p1":
                GetComponent<TMPro.TextMeshProUGUI>().text = "Health: " + prefab_player1_script.health.ToString();
                break;
            case "health_p2":
                if (manager_game_script.is_coop)
                {
                    GetComponent<TMPro.TextMeshProUGUI>().text = "Health: " + prefab_player2_script.health.ToString();
                }
                break;
            case "death_p1":
                if (GameObject.Find("prefab_player1_death_head") != null)
                {
                    sum_int = (int)prefab_player1_death_head_script.timer_death;
                    GetComponent<TMPro.TextMeshProUGUI>().text = "Death: " + sum_int.ToString();
                }
                if (GameObject.Find("prefab_player1_death_torso") != null)
                {
                    sum_int = (int)prefab_player1_death_torso_script.timer_death;
                    GetComponent<TMPro.TextMeshProUGUI>().text = "Death: " + sum_int.ToString();
                }
                if (GameObject.Find("prefab_player1_death_limbs") != null)
                {
                    sum_int = (int)prefab_player1_death_limbs_script.timer_death;
                    GetComponent<TMPro.TextMeshProUGUI>().text = "Death: " + sum_int.ToString();
                }
                else
                {
                    GetComponent<TMPro.TextMeshProUGUI>().text = "Death: -";
                }
                break;
            case "death_p2":
                if (manager_game_script.is_coop)
                {
                    if (GameObject.Find("prefab_player2_death_head") != null)
                    {
                        sum_int = (int)prefab_player2_death_head_script.timer_death;
                        GetComponent<TMPro.TextMeshProUGUI>().text = "Death: " + sum_int.ToString();
                    }
                    if (GameObject.Find("prefab_player2_death_torso") != null)
                    {
                        sum_int = (int)prefab_player2_death_torso_script.timer_death;
                        GetComponent<TMPro.TextMeshProUGUI>().text = "Death: " + sum_int.ToString();
                    }
                    if (GameObject.Find("prefab_player2_death_limbs") != null)
                    {
                        sum_int = (int)prefab_player2_death_limbs_script.timer_death;
                        GetComponent<TMPro.TextMeshProUGUI>().text = "Death: " + sum_int.ToString();
                    }
                    else
                    {
                        GetComponent<TMPro.TextMeshProUGUI>().text = "Death: -";
                    }
                }
                break;
            case "head_p1":
                if (data_p1[0].Contains("dwarf"))
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_head)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Dwarf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else if (data_p1[0].Contains("elf"))
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_head)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Elf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_head)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Goblin_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                break;
            case "torso_p1":
                if (data_p1[1].Contains("dwarf"))
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_torso)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Dwarf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else if (data_p1[1].Contains("elf"))
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_torso)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Elf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_torso)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Goblin_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                break;
            case "hands_p1":
                if (data_p1[2].Contains("cannon"))
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Cannon");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_limbs)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Cannon");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Cannon");
                        Spriterenderer.enabled = false;
                    }
                }
                else
                {
                    if (GameObject.Find("prefab_player1(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Crossbow");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player2_script.has_limbs)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Crossbow");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Crossbow");
                        Spriterenderer.enabled = false;
                    }
                }
                break;
            case "legs_p1":
                if (GameObject.Find("prefab_player1(Clone)") != null)
                {
                    SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                    Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Legs_Idle");
                    Spriterenderer.enabled = true;
                }
                else if (prefab_player2_script.has_limbs)
                {
                    SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                    Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Legs_Idle");
                    Spriterenderer.enabled = true;
                }
                else
                {
                    SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                    Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Legs_Idle");
                    Spriterenderer.enabled = false;
                }
                break;
            case "head_p2":
                if (data_p2[0].Contains("dwarf"))
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_head)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Dwarf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else if (data_p2[0].Contains("elf"))
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_head)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Elf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_head)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Heads_Goblin_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                break;
            case "torso_p2":
                if (data_p2[1].Contains("dwarf"))
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_torso)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Dwarf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Dwarf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else if (data_p2[1].Contains("elf"))
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_torso)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Elf_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Elf_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                else
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_torso)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Goblin_Idle1");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Torso_Goblin_Idle1");
                        Spriterenderer.enabled = false;
                    }
                }
                break;
            case "hands_p2":
                if (data_p2[2].Contains("cannon"))
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Cannon");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_limbs)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Cannon");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Cannon");
                        Spriterenderer.enabled = false;
                    }
                }
                else
                {
                    if (GameObject.Find("prefab_player2(Clone)") != null)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Crossbow");
                        Spriterenderer.enabled = true;
                    }
                    else if (prefab_player1_script.has_limbs)
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Crossbow");
                        Spriterenderer.enabled = true;
                    }
                    else
                    {
                        SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                        Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Hands_Crossbow");
                        Spriterenderer.enabled = false;
                    }
                }
                break;
            case "legs_p2":
                if (GameObject.Find("prefab_player2(Clone)") != null)
                {
                    SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                    Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Legs_Idle");
                    Spriterenderer.enabled = true;
                }
                else if (prefab_player1_script.has_limbs)
                {
                    SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                    Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Legs_Idle");
                    Spriterenderer.enabled = true;
                }
                else
                {
                    SpriteRenderer Spriterenderer = GetComponent<SpriteRenderer>();
                    Spriterenderer.sprite = Resources.Load<Sprite>("Sprites/Legs_Idle");
                    Spriterenderer.enabled = false;
                }
                break;
        }
    }
}