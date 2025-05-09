using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class prefab_fade : MonoBehaviour
{
    SpriteRenderer spriterenderer;
    private bool fade_in = true;
    private float timer_fade = 0;
    public bool fade_out = false;
    public string level_next;
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (fade_in)
        {
            timer_fade += Time.deltaTime;
            if (0.5f > timer_fade && timer_fade >= 0.25f)
            {
                Set_Alpha(0.75f);
            }
            else if (0.75f > timer_fade && timer_fade >= 0.5f)
            {
                Set_Alpha(0.5f);
            }
            else if (1f > timer_fade && timer_fade >= 0.75f)
            {
                Set_Alpha(0.25f);
            }
            else if (timer_fade >= 1f)
            {
                Set_Alpha(0);
                fade_in = false;
                timer_fade = 0;
            }
        }
        else if (fade_out)
        {
            timer_fade += Time.deltaTime;
            if (0.5f > timer_fade && timer_fade >= 0.25f)
            {
                Set_Alpha(0.25f);
            }
            else if (0.75f > timer_fade && timer_fade >= 0.5f)
            {
                Set_Alpha(0.5f);
            }
            else if (1f > timer_fade && timer_fade >= 0.75f)
            {
                Set_Alpha(0.75f);
            }
            else if (timer_fade >= 1f)
            {
                Set_Alpha(1f);
                SceneManager.LoadScene(level_next);
            }
        }
    }
    void Set_Alpha(float alpha)
    {
        Color color = spriterenderer.color;
        color.a = alpha;
        spriterenderer.color = color;
    }
}