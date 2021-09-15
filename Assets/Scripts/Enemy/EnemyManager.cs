using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    #region Singleton

    public static EnemyManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject enemy;
}
