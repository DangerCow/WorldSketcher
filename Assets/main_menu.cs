using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    public Button back;
    public Button quit_btn;
    public Button apply_btn;
    public Dropdown res_dpd;
    public Toggle full_screen_tgl;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, false);

        back.onClick.AddListener(back_func);
        quit_btn.onClick.AddListener(quit);
        apply_btn.onClick.AddListener(apply);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void back_func()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void quit()
    {
        Application.Quit();
    }
    void apply()
    {
        if (res_dpd.value == 0)
        {
            Screen.SetResolution(2560, 1440, full_screen_tgl.isOn);
        }
        if (res_dpd.value == 1)
        {
            Screen.SetResolution(1920, 1080, full_screen_tgl.isOn);
        }
        if (res_dpd.value == 2)
        {
            Screen.SetResolution(1024, 768, full_screen_tgl.isOn);
        }
    }
}
