using UnityEngine;
using System.Collections;



public class FPSDisplay : MonoBehaviour
{   
	public float deltaTime = 0.0f;

    float fOneTick;
    GUIStyle style = new GUIStyle();
    Rect rect;

    System.Collections.Generic.List<float> _lstFps = new System.Collections.Generic.List<float>();

    void Start()
    {
#if READ
#elif UNITY_EDITOR || DEBUG_MODE
        ReporterCommend.GetInstance().showFPS = true;
#endif
        int w = Screen.width, h = Screen.height;
        rect = new Rect(Screen.width / 10f, h - 100, w, h * 2 / 150);

        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 3 / 150;
        style.normal.textColor = new Color(1.0f, 0.0f, 0.5f, 1.0f);        
    }

    void OnApplicationQuit()
    {

    }

	void Update()
	{
        if( ReporterCommend.GetInstance().showFPS == false )
        {
            return;
        }

        UpdateFPS();

        if (Time.timeScale >= 1)            
		    deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

        if (fOneTick > 0)
        {
            fOneTick -= Time.deltaTime;
            if (fOneTick <= 0)
            {
                Time.timeScale = 0f;
                fOneTick = -1f;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            Time.timeScale = 1f;
            fOneTick = 0.00001f;
        }

        if (Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Plus))
        {
            Time.timeScale += 0.1f;
        }
        else if (Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.Minus))
        {
            if (Time.timeScale >= 0.1f)
            {
                Time.timeScale -= 0.1f;
            }

        }
        else if (Input.GetKeyUp(KeyCode.KeypadDivide))
        {
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.KeypadMultiply))
        {
            Time.timeScale = 1f;
        }

//#if UNITY_EDITOR        
//        if (UnityEditor.UnityStats.batches >= 70 && MAssist.MViewer.instance.isOpen == false
//            && SceneManager.GetInstance().GetLoadingStep() == SceneManager.LoadingStep.None)
//        {
//            UnityEditor.EditorApplication.isPaused = true;
//        }
//#endif
    }

    float frames = 0;
    float timeElap = 0;
    float frametime = 0;
    string strFps = "";
    void UpdateFPS()
    {
        frames++;
        timeElap += Time.unscaledDeltaTime;
        if (timeElap > 1)
        {
            int w = Screen.width, h = Screen.height;
            rect = new Rect(Screen.width / 10f, h - 100, w, h * 2 / 150);

            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 3 / 150;
            style.normal.textColor = new Color(1.0f, 0.0f, 0.5f, 1.0f);
            frametime = timeElap / (float)frames;
            timeElap -= 1f;
            strFps = string.Format("FPS : {0}, Fram : {1:F2} ms, {2:F1} \nScreen {3} / {4} / {5} ", frames, frametime * 1000.0f, Time.timeScale, Screen.currentResolution.width, Screen.currentResolution.height,
                Screen.dpi);
                //AppManager.GetInstance()._screenResolution);
            frames = 0;
        }
    }

    public float msec;
    public float fps;
	void OnGUI()
	{
        if (ReporterCommend.GetInstance().showFPS == false)
        {
            return;
        }
        GUI.Label(rect, strFps, style);
    }
}
