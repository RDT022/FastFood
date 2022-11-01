using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaling : MonoBehaviour
{
    public GameObject PhoneUI;

    public void OpenUI()
    {
        if (PhoneUI != null)
        {
            Animator animator = PhoneUI.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("open");

                animator.SetBool("open", !isOpen);
            }
        }
    }


}
