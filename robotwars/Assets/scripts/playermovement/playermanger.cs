using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanger : MonoBehaviour
{
    #region singleton
    public static playermanger instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
}

