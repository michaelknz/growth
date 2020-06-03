using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float max_offset_x;
    public float max_offset_y;
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

    }
    void LateUpdate()
    {
        float del_x, del_y;
        del_x = Mathf.Max(max_offset_x, (player.transform.position.x - transform.position.x)) + Mathf.Min(-max_offset_x, (player.transform.position.x - transform.position.x));
        del_y = Mathf.Max(max_offset_y, (player.transform.position.y - transform.position.y)) + Mathf.Min(-max_offset_y, (player.transform.position.y - transform.position.y));
        transform.position += new Vector3(del_x, del_y, 0);
    }
}
