using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapObjMarker : MonoBehaviour
{
    [SerializeField]
    private LocationHolder lh;

    private GameObject compassTarget;

    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        compassTarget = lh.ActivePoint;
    }

    // Update is called once per frame
    void Update()
    {
        compassTarget = lh.ActivePoint;
        Vector3 targ = compassTarget.transform.position;
        targ.z = 0f;

        Vector3 objectPos = player.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
