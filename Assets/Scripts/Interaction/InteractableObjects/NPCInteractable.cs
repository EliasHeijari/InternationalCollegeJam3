using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    private string text = "Help Him/Her";

    public void Interact(Transform interactorTransform)
    {
        Debug.Log("You Interact With Him/Her");
    }

    public string GetInteractText()
    {
        return text;
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
