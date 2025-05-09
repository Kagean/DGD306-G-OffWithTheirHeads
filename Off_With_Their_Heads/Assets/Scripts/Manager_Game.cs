using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class manager_game : MonoBehaviour
{
    public bool is_coop;
    public int count_credit = 3;
    public List<string> data_p1;
    public List<string> data_p2;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        
    }
}