using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovingPlatform : PuzzleMechanism
{

    [SerializeField] Vector3 activatedOffset;
    [SerializeField] float platformSpeed = 1.0f;

    [SerializeField] bool alwaysActivated = false;

    Vector3 pos1;
    Vector3 pos2;

    bool moving = false;

    bool stopAtFirst = false;
    bool stopAtSecond = false;

    bool stoppedOnce = false;


    float t = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position + activatedOffset;
        if (alwaysActivated) moving = true;
    }

    public override void Activate()
    {
        moving = true;
    }

    public override void Deactivate()
    {
        if(!alwaysActivated) moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = new Vector3(pos1.x + PingPong(t, pos2.x - pos1.x), pos1.y + PingPong(t, pos2.y - pos1.y), pos1.z + PingPong(t, pos2.z - pos1.z));

            if(!stopAtFirst && !stopAtSecond)
            {
                if(Vector3.Distance(transform.position, pos1) < 0.05f)
                {
                    stopAtFirst = true;
                }
                if(Vector3.Distance(transform.position, pos2) < 0.05f)
                {
                    stopAtSecond = true;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, pos1) > 0.05f && stopAtFirst)
                {
                    stopAtFirst = false;
                    stoppedOnce = false;
                }
                if (Vector3.Distance(transform.position, pos2) > 0.05f && stopAtSecond)
                {
                    stopAtSecond = false;
                    stoppedOnce = false;
                }
            }

            if(!stoppedOnce && (stopAtFirst || stopAtSecond))
            {
                stoppedOnce = true;
                StartCoroutine(StopMovingForSeconds(1.5f));
            }



            t += Time.deltaTime * platformSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 gizmoPos = transform.position + activatedOffset + new Vector3(0.5f, 0.5f, -0.5f);
        Gizmos.DrawWireCube(gizmoPos, Vector3.one);
    }

    float PingPong(float timer, float value)
    {
        if (value == 0) return 0;

        return Mathf.PingPong(timer, value);

    }

    void OnCollisionEnter(Collision col)
    {
        col.collider.gameObject.transform.parent = transform;
    }

    void OnCollisionExit(Collision col)
    {
        col.collider.gameObject.transform.parent = null;
    }

    IEnumerator StopMovingForSeconds(float t)
    {
        moving = false;
        yield return new WaitForSeconds(t);
        moving = true;
    }
}
