using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProtalControl : MonoBehaviour {

    public int numCargos;

    bool canEntered;

    //Store the information which how many cargos are collected
    bool[] actives;

    void Start()
    {
        actives = new bool[numCargos];    
    }

    public void ActiviteOneOfCargoHolder()
    {
        for(int i = 0; i < actives.Length; i++)
        {
            if(!actives[i])
            {
                actives[i] = true;
                canEntered = CheckAllActived();
                return;
            }
        }
    }

    bool CheckAllActived()
    {
        foreach(bool active in actives)
        {
            if(!active)
            {
                return false;
            }
        }
        return true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(canEntered && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
