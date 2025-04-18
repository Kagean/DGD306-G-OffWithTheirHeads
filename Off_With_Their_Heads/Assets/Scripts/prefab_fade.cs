using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class prefab_fade : MonoBehaviour
{
    SpriteRenderer spriterenderer;
    private bool fade_in = true;
    private float timer = 0;
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
            timer += Time.deltaTime;
            if (0.5f > timer && timer >= 0.25f)
            {
                SetAlpha(0.75f);
            }
            else if (0.75f > timer && timer >= 0.5f)
            {
                SetAlpha(0.5f);
            }
            else if (1f > timer && timer >= 0.75f)
            {
                SetAlpha(0.25f);
            }
            else if (timer >= 1f)
            {
                SetAlpha(0);
                fade_in = false;
                timer = 0;
            }
        }
        if (fade_out)
        {
            timer += Time.deltaTime;
            if (0.5f > timer && timer >= 0.25f)
            {
                SetAlpha(0.25f);
            }
            else if (0.75f > timer && timer >= 0.5f)
            {
                SetAlpha(0.5f);
            }
            else if (1f > timer && timer >= 0.75f)
            {
                SetAlpha(0.75f);
            }
            else if (timer >= 1f)
            {
                SetAlpha(1f);
                SceneManager.LoadScene(level_next);
            }
        }
    }
    void SetAlpha(float alpha)
    {
        Color color = spriterenderer.color;
        color.a = alpha;
        spriterenderer.color = color;
    }
}