using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class prefab_camera_movement_change : MonoBehaviour
{
    public string direction;
    void Start()
    {
        gameObject.name = "prefab_camera_movement_change_" + direction;
    }
}