using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public static class Util
{
    static public UILabel GetUILabel(Transform transform, string strName)
    {
        UILabel lbl = transform.Find(strName).GetComponent<UILabel>();
        if (lbl == null)
        {
            Debug.LogErrorFormat("error {0} {1} null", transform.name, strName);
            return null;
        }
        return lbl;
    }

    // 테스트 주석

    static public UIButton GetUIButton(Transform transform, string strName)
    {
        Transform trm = transform.Find(strName);
        if (trm == null)
        {
            Debug.LogErrorFormat("error {0} {1} null", transform.name, strName);
            return null;
        }

        UIButton btn = trm.GetComponent<UIButton>();
        if (btn == null)
        {
            Debug.LogErrorFormat("error {0} {1} null", transform.name, strName);
            return null;
        }
        return btn;
    }

    public static T GetComponent<T>(Transform transform, string strName)
    {
        Transform trm = null;
        if (string.IsNullOrEmpty(strName))
        {
            trm = transform;
        }
        else
        {
            trm = transform.Find(strName);
            if (trm == null)
            {
                Debug.LogErrorFormat("error {0} {1} null Object", transform.name, strName);
                return default(T);
            }
        }

        T btn = trm.GetComponent<T>();
        if (btn == null)
        {
            Debug.LogErrorFormat("error {0} {1} null Component", transform.name, strName);
            return default(T);
        }
        return btn;
    }

    public static bool IsNotComponentOrNull(Component com)
    {
        if (com == null)
        {
            Debug.LogError("Component Null");
            return false;
        }

        return true;
    }

    public static int ConvertInt(string str)
    {
        int numChk = 0;
        bool isNum = int.TryParse(str, out numChk);
        if (!isNum)
        {
            return 0;
        }
        else
        {
            return numChk;
        }

    }

    public static void Assert(object obj, string message)
    {
        UnityEngine.Assertions.Assert.IsNull(obj, message);
    }


    public static void SaveFile(string fileName, string data)
    {
        StreamWriter m_LogStreamWriter = null;
        string m_strLogPaht = fileName;
        FileInfo pFileInfo = new FileInfo(m_strLogPaht);
        m_LogStreamWriter = new StreamWriter(m_strLogPaht, false, System.Text.Encoding.UTF8);
        m_LogStreamWriter.WriteLine(data);
        Debug.LogWarningFormat("File Size {0}", m_strLogPaht.Length);
        m_LogStreamWriter.Close();
    }

    public static void SaveFile(string fileName, byte[] data)
    {
        StreamWriter m_LogStreamWriter = null;
        string m_strLogPaht = fileName;
        FileInfo pFileInfo = new FileInfo(m_strLogPaht);
        m_LogStreamWriter = new StreamWriter(m_strLogPaht, false, System.Text.Encoding.UTF8);

        m_LogStreamWriter.BaseStream.Write(data, 0, data.Length);
        Debug.LogWarningFormat("File Size {0}", m_strLogPaht.Length);
        m_LogStreamWriter.Close();
    }

    public static string GetCandySpriteName(int candyTypeNum)
    {
        if (candyTypeNum >= (int)CandyType.CandyType_Color && candyTypeNum <= (int)CandyType.CandyType_Color + 6)
        {
            return string.Format("candy_{0:D2}", candyTypeNum - (int)CandyType.CandyType_Color);
        }
        if (candyTypeNum >= (int)CandyType.CandyType_Balloon && candyTypeNum <= (int)CandyType.CandyType_Balloon + 6)
        {
            return string.Format("balloon_{0}", candyTypeNum - (int)CandyType.CandyType_Balloon);
        }
        if (candyTypeNum >= (int)CandyType.CandyType_ColorMonster_Eater && candyTypeNum <= (int)CandyType.CandyType_ColorMonster_Eater + 6)
        {
            return string.Format("icecream_{0:D2}", candyTypeNum - (int)CandyType.CandyType_ColorMonster_Eater);
        }
        if (candyTypeNum >= (int)CandyType.CandyType_Dice && candyTypeNum <= (int)CandyType.CandyType_Dice + 6)
        {
            return string.Format("dice_{0:D2}", candyTypeNum - (int)CandyType.CandyType_Dice);
        }
        if (candyTypeNum == (int)CandyType.CandyType_Monster_Eater)
        {
            return string.Format("icecream_07");
        }

        return string.Format("candy_{0}", candyTypeNum);
    }

    static public int StringToInt(string str)
    {
        int _nNum = 0;
        if (str.Length == 0)
            return 0;
        int.TryParse(str, out _nNum);
        return _nNum;
    }
        
    static public float StringToFloat(string str)
    {
        float _fNum = 0;
        _fNum = 0;
        if (str.Length == 0)
            return 0;
        float.TryParse(str, out _fNum);
        return _fNum;
    }

    static public void AddOnEvent(MonoBehaviour target, List<EventDelegate> list, string method, object value, System.Type type)
    {
        EventDelegate onClickEvent = new EventDelegate(target, method);

        EventDelegate.Parameter param = new EventDelegate.Parameter();
        param.value = value;
        param.expectedType = type;
        onClickEvent.parameters[0] = param;

        EventDelegate.Add(list, onClickEvent);
    }
}
