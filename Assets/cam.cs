using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float zoom_Speed = 1f;
    public float min_speed = 1f;
    public float max_speed = 1f;
    public float div = 1f;
    public float zoom = 0f;

    public bool active = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            zoom = Camera.main.orthographicSize;

            float cspeed = min_speed + zoom / div;
            cspeed = Mathf.Clamp(cspeed, 0, max_speed);

            float h_speed = Input.GetAxis("Horizontal") * cspeed;
            float v_speed = Input.GetAxis("Vertical") * cspeed;

            transform.Translate(h_speed, v_speed, 0);
            transform.position = new Vector3(transform.position.x, transform.position.y, -100);
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom_Speed;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 0.1f, 165);
        }
    }
}
