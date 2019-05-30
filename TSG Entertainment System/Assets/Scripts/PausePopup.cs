using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePopup : MonoBehaviour
{
    public GameObject PopupPanel;
    public GameObject PauseScriptContainer;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenPanel()
    {
        if (PopupPanel != null)
        {
            Animator animator = PopupPanel.GetComponent<Animator>();
            if (animator != null)
            {
                isOpen = animator.GetBool("ShowMenu");

                animator.SetBool("ShowMenu", !isOpen);
            }
        }
    }

    public void PauseToggle()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
