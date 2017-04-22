using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public enum Status
    {
        Active,
        Inactive
    }

    [SerializeField] GameObject UIPanel = null;

    Status status;

    void Start()
    {
        status = Status.Inactive;
        UIPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (status == Status.Active)
            {
                Close();
            }
            else if (status == Status.Inactive)
            {
                Open();
            }
        }
    }

    void Open()
    {
        Time.timeScale = 0;
        status = Status.Active;
        UIPanel.SetActive(true);
    }

    public void Close()
    {
        Time.timeScale = 1;
        status = Status.Inactive;
        UIPanel.SetActive(false);
    }
}

