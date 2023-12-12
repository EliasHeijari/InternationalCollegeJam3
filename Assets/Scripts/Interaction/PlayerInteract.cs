using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    [SerializeField] private GameObject NpcUiGameObject;
    private NPC.NpcType interactingNpcsType;
    private NPC interactingNPC;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && !NpcUiGameObject.activeSelf) {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null) {
                interactable.Interact(transform);
                if (interactable.GetTransform().TryGetComponent(out NPC npc))
                {
                    NpcUiGameObject.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    interactingNpcsType = npc.type;
                    interactingNPC = npc;
                    Debug.Log(interactingNpcsType.ToString());
                }
            }
            else
            {
                NpcUiGameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.E))
        {
            NpcUiGameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void GiveAlcohol()
    {
        switch (interactingNpcsType)
        {
            case NPC.NpcType.Alcoholic:
                interactingNPC.Emotion = NPC.NpcEmotion.Happy;
                break;
            case NPC.NpcType.Homeless:
                interactingNPC.Emotion = NPC.NpcEmotion.Neutral;
                break;
            case NPC.NpcType.DrugAddict:
                interactingNPC.Emotion = NPC.NpcEmotion.Neutral;
                break;
            case NPC.NpcType.Lonely:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
        }
        Debug.Log($"NPC's emotion: {interactingNPC.Emotion.ToString()}");
    }

    public void GiveDrugs()
    {
        switch (interactingNpcsType)
        {
            case NPC.NpcType.Alcoholic:
                interactingNPC.Emotion = NPC.NpcEmotion.Neutral;
                break;
            case NPC.NpcType.Homeless:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
            case NPC.NpcType.DrugAddict:
                interactingNPC.Emotion = NPC.NpcEmotion.Happy;
                break;
            case NPC.NpcType.Lonely:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
        }
        Debug.Log($"NPC's emotion: {interactingNPC.Emotion.ToString()}");
    }

    public void GiveHat()
    {
        switch (interactingNpcsType)
        {
            case NPC.NpcType.Alcoholic:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
            case NPC.NpcType.Homeless:
                interactingNPC.Emotion = NPC.NpcEmotion.Happy;
                break;
            case NPC.NpcType.DrugAddict:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
            case NPC.NpcType.Lonely:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
        }
        Debug.Log($"NPC's emotion: {interactingNPC.Emotion.ToString()}");
    }

    public void GiveHug()
    {
        switch (interactingNpcsType)
        {
            case NPC.NpcType.Alcoholic:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
            case NPC.NpcType.Homeless:
                interactingNPC.Emotion = NPC.NpcEmotion.Neutral;
                break;
            case NPC.NpcType.DrugAddict:
                interactingNPC.Emotion = NPC.NpcEmotion.Sad;
                break;
            case NPC.NpcType.Lonely:
                interactingNPC.Emotion = NPC.NpcEmotion.Happy;
                break;
        }
        Debug.Log($"NPC's emotion: {interactingNPC.Emotion.ToString()}");
    }

    public IInteractable GetInteractableObject() {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray) {
            if (collider.TryGetComponent(out IInteractable interactable)) {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList) {
            if (closestInteractable == null) {
                closestInteractable = interactable;
            } else {
                if (Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                    Vector3.Distance(transform.position, closestInteractable.GetTransform().position)) {
                    // Closer
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }

}