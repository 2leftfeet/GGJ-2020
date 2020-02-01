using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : PuzzleMechanism
{
    [SerializeField] Vector3 activatedPositionChange;

    Vector3 deactivatedPos;
    Vector3 activatedPos;

    Vector3 targetPos;

    void Start()
    {
        deactivatedPos = transform.position;
        activatedPos = transform.position + activatedPositionChange;

        targetPos = deactivatedPos;
    }

    public override void Activate()
    {
        targetPos = activatedPos;
    }

    public override void Deactivate()
    {
        targetPos = deactivatedPos;
    }

    void Update()
    {
        transform.position += 0.1f * (targetPos - transform.position);
    }
}
