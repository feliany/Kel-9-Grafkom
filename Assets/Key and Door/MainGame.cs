using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour
{
    public GameObject Key1, Key2, Key3, Key4, Key5;
    static public MainGame Instance;

    private void Awake()
    {
        Instance = this;
        Randomize();
    }

    public void Randomize()
    {
        int x = Random.Range(1, 5);
        if(x == 1)
        {
            Key1.SetActive(true);
        }
        else if (x == 2)
        {
            Key2.SetActive(true);
        }
        else if (x == 3)
        {
            Key3.SetActive(true);
        }
        else if (x == 4)
        {
            Key4.SetActive(true);
        }
        else if (x == 5)
        {
            Key5.SetActive(true);
        }
    }
}
