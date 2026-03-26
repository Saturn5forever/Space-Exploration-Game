using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class TractorBeam : MonoBehaviour
{
    public float cooldownDuration = 20f;
    public float beamTime = 5f;
    public Image cooldownOverlay;
    private float remainingTime;
    private bool canActivate = true;
    public InputAction tractorKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tractorKey.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (tractorKey.WasPressedThisFrame() && canActivate == true)
        {
            GetComponent<Gravity>().enabled = true;
            canActivate = false;
            StartCoroutine(TractorBeamCooldown());

        }
    }
    IEnumerator TractorBeamCooldown()
    {
        remainingTime = cooldownDuration;
        yield return new WaitForSeconds(beamTime);
        GetComponent<Gravity>().enabled = false;

        cooldownOverlay.fillAmount = 1f;
        while (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            UpdateCooldownUI();
            yield return null;
        }
        canActivate = true;
        cooldownOverlay.fillAmount = 0f;
    }

    void UpdateCooldownUI()
    {
        cooldownOverlay.fillAmount = remainingTime / cooldownDuration;
    }
}
