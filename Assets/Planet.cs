using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public bool update;

    public bool change_color;
    public Color color;

    public bool use_parent;
    public Planet parent_body;
    public float orbit_speed;
    public float x;
    private planet_slector planet_Slector;
    private Toggle orbit_togle;

    private new SpriteRenderer renderer;

    public bool orbit_pause = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject slector_object = GameObject.FindWithTag("selector");
        orbit_togle = GameObject.FindWithTag("orbit toggle").GetComponent<Toggle>();


        planet_Slector = slector_object.GetComponent<planet_slector>();
        renderer = GetComponent<SpriteRenderer>();
        update_body();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (update == true)
        {
            update = false;
            update_body();
        }

        orbit_pause = !orbit_togle.isOn;

        if (use_parent && !orbit_pause)
        {
            transform.parent = parent_body.transform;
            transform.RotateAround(parent_body.transform.position, Vector3.forward, orbit_speed * Time.deltaTime);
        }
    }

    void update_body()
    {
        if (change_color)
        {
            renderer.color = color;
        }
    }

    private void OnMouseDown()
    {
        planet_Slector.pln_name = gameObject.name;
    }
}
