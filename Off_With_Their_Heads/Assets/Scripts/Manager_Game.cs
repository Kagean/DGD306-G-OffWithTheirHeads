using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class manager_game : MonoBehaviour
{
    public bool is_coop = false;
    public int count_coin = 3;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        
    }
}