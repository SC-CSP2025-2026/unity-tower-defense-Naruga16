using UnityEngine;
using System.Collections.Generic;

public class AOETurret : MonoBehaviour
{
    [field: SerializeField]
    public AreaOfEngagement AoE { get; private set; }

    [field: SerializeField]
    public Projectile ProjectilePrefab { get; private set; }

    [field: SerializeField]
    public float CooldownTime { get; private set; } = 3f;

    [field: SerializeField]
    public bool IsCoolingDown { get; private set; } = false;

    void Update()
    {
        AoE.Targets.RemoveAll(t => t == null);

        if (Time.frameCount % 60 == 0)
        {
            Debug.Log($"[AOETurret] Targets in range: {AoE.Targets.Count} | Cooling: {IsCoolingDown}");
        }

        if (IsCoolingDown || AoE.Targets.Count == 0)
            return;

        FireAll();
        IsCoolingDown = true;
        Invoke(nameof(SetIsCoolingDownToFalse), CooldownTime);
    }

    public void SetIsCoolingDownToFalse()
    {
        IsCoolingDown = false;
    }

    public void FireAll()
    {
    List<Health> targets = new List<Health>(AoE.Targets);
    Debug.Log($"[AOETurret] Firing at {targets.Count} enemies!");

    foreach (Health target in targets)
    {
        if (target == null || target.gameObject == null) continue;

        Projectile newProjectile = Instantiate(ProjectilePrefab);
        newProjectile.transform.position = transform.position;
        newProjectile.Target = target.transform.root;

        Debug.Log($"[AOETurret] Shot fired at: {target.gameObject.name}");
    }
    }
}