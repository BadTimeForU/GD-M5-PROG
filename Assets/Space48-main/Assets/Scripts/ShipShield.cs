using UnityEngine;
using System;

public class ShipShield : MonoBehaviour
{
    [SerializeField] float maxEnergy = 5f;
    [SerializeField] float drainRate = 1f;
    [SerializeField] float regenRate = 0.5f;
    [SerializeField] float regenDelay = 2f;

    float currentEnergy;
    bool active;
    float regenTimer;

    public event Action<float> OnEnergyChanged;

    void Start()
    {
        currentEnergy = maxEnergy;
    }

    public void Activate()
    {
        if (currentEnergy <= 0f) return;
        active = true;
    }

    public void Deactivate()
    {
        if (active)
        {
            active = false;
            regenTimer = 0f;
        }
    }

    void Update()
    {
        if (active)
        {
            currentEnergy -= drainRate * Time.deltaTime;
            if (currentEnergy <= 0f)
            {
                currentEnergy = 0f;
                Deactivate();
            }
            OnEnergyChanged?.Invoke(currentEnergy);
        }
        else
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= regenDelay)
            {
                currentEnergy = Mathf.Min(maxEnergy, currentEnergy + regenRate * Time.deltaTime);
                OnEnergyChanged?.Invoke(currentEnergy);
            }
        }
    }

    public bool IsActive => active;
}