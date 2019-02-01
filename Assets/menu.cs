using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public Button mainmenu;
    public Slider speed_slider;
    public Text speed_text;

    // Start is called before the first frame update
    void Start()
    {
        mainmenu.onClick.AddListener(main_menu);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = speed_slider.value;
        speed_text.text = "time warp: " + speed_slider.value + "x";
    }

    void main_menu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
