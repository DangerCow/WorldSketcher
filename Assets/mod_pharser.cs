using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class mod_pharser : MonoBehaviour
{
    public Sprite planet;

    string myLog;
    Queue myLogQueue = new Queue();

    Dictionary<string, GameObject> new_bodys = new Dictionary<string, GameObject>();

    private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        string[] files = System.IO.Directory.GetFiles(Application.dataPath, "*.ws");

        sprites = sprites = Resources.LoadAll<Sprite>("");

        foreach (string file in files)
        {
            pharser(file);
        }
    }

    void pharser(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);
        string Body_name = "";
        Planet pln = null;
        SpriteRenderer ren = null;
        CircleCollider2D col = null;

        foreach (string line in lines)
        {
            if (line.StartsWith("Body"))
            {
                if(line.StartsWith("Body = new "))
                {
                    Body_name = line.Split('>')[1];
                    new_bodys.Add(Body_name, new GameObject(Body_name));

                    new_bodys[Body_name].AddComponent<Planet>();
                    pln = new_bodys[Body_name].GetComponent<Planet>();
                    pln.change_color = true;
                    pln.use_parent = true;

                    ren = new_bodys[Body_name].AddComponent<SpriteRenderer>();
                    ren.sprite = planet;

                    col = new_bodys[Body_name].AddComponent<CircleCollider2D>();
                }

                if(line.StartsWith("Body.Parent "))
                {
                    if (pln != null)
                    {
                        pln.parent_body = GameObject.Find(line.Split('>')[1]).GetComponent<Planet>();
                    }
                }

                if(line.StartsWith("Body.Color "))
                {
                    Color color = new Color(float.Parse(line.Split('>')[1]) / 255, float.Parse(line.Split('>')[2]) / 255, float.Parse(line.Split('>')[3]) / 255);

                    pln.color = color;
                }

                if (line.StartsWith("Body.X "))
                {
                    pln.transform.position = new Vector3(pln.parent_body.transform.position.x + float.Parse(line.Split('>')[1]), 0, 0);
                }

                if (line.StartsWith("Body.Size "))
                {
                    pln.transform.localScale = new Vector3(float.Parse(line.Split('>')[1]), float.Parse(line.Split('>')[1]), float.Parse(line.Split('>')[1]));
                }

                if (line.StartsWith("Body.Orbit_speed "))
                {
                    pln.orbit_speed = float.Parse(line.Split('>')[1]);
                }
            }
        }

        pln.update = true;
    }

    // debuger

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        myLog = logString;
        string newString = "\n [" + type + "] : " + myLog;
        myLogQueue.Enqueue(newString);
        if (type == LogType.Exception)
        {
            newString = "\n" + stackTrace;
            myLogQueue.Enqueue(newString);
        }
        myLog = string.Empty;
        foreach (string mylog in myLogQueue)
        {
            myLog += mylog;
        }
    }

    void OnGUI()
    {
        GUILayout.Label(myLog);
    }
}
