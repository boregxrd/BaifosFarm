using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transicion : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject panel;

    public void FadeOut() {
        panel.SetActive(true);
        animator.SetTrigger("fadeOut");
    }

    public void FadeIn() {
        animator.SetTrigger("fadeIn");
    }
}
