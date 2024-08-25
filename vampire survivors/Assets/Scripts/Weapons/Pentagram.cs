using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour
{
    public WeaponsAndItems weaponsAndItems;
    public BoxCollider2D boxCollider;
    private Coroutine activeCoroutine;
    private int lastPentagramLevel;

    private void Start()
    {
        boxCollider.enabled = false;
        lastPentagramLevel = weaponsAndItems.PentagramLevel;
        activeCoroutine = StartCoroutine(ActivateBoxCollider());
    }

    private void Update()
    {
        if (weaponsAndItems.PentagramLevel != lastPentagramLevel)
        {
            lastPentagramLevel = weaponsAndItems.PentagramLevel;
            if (activeCoroutine != null)
            {
                StopCoroutine(activeCoroutine);
            }
            activeCoroutine = StartCoroutine(ActivateBoxCollider());
        }
    }

    private IEnumerator ActivateBoxCollider()
    {
        while (weaponsAndItems.isPentagramEquipped)
        {
            float delay = GetActivationDelay();
            Debug.Log("Waiting for " + delay + " seconds before activating collider.");
            yield return new WaitForSeconds(delay);

            Debug.Log("Pentagram collider activated!");
            boxCollider.enabled = true;
            yield return new WaitForSeconds(0.3f);

            boxCollider.enabled = false;
            Debug.Log("Pentagram collider deactivated!");
        }
    }

    private float GetActivationDelay()
    {
        Debug.Log("Pentagram Level: " + weaponsAndItems.PentagramLevel);
        switch (weaponsAndItems.PentagramLevel)
        {
            case 1:
                return 120f;
            case 2:
                return 60f;
            case 3:
                return 30f;
            default:
                return 120f;
        }
    }
}
