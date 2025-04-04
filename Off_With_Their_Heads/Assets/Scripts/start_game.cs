using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start_game : MonoBehaviour
{
    private bool lock_startgame = true;
    private float timer = 0;
    public GameObject prefab_fadeout;
    void Start()
    {
        
    }
    void Update()
    {
        if (lock_startgame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                lock_startgame = false;
                Instantiate(prefab_fadeout, transform.position + new Vector3(0, 0, 0), transform.rotation);
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                SceneManager.LoadScene("menu_selection");
            }
        }
    }
}