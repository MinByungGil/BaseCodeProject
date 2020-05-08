using UnityEngine;
using System.Collections;

public class SecuriyNumber
{
    protected int securityKey = 0;

    public SecuriyNumber()
    {
        GenerateSecuriyKey();
    }

    protected void GenerateSecuriyKey()
    {
        securityKey = UnityEngine.Random.Range(1, int.MaxValue);
    }

    protected void AlertGameHacking()
    {
        PopupManager.OpenRestartPopup(LocalizedString.GetString("2501"), PopupButtonType.CONFIRM);
    }

    private void OnCloseMessageBox()
    {

    }

#if DEBUG_MODE
    static void TextSecuriyNumber()
    {

    }
#endif
};

[System.Serializable]
public class Sint : SecuriyNumber
{
    [SerializeField]
    private int _value; // 보이기 용
    private int _data; // 실제 저장 값

    public Sint(int value)
    {
        SetValue(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator Sint(int value)
    {
        return new Sint(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator int(Sint value)
    {
        return value.GetValue();
    }

    public static Sint operator ++(Sint inSInt)
    {
        var value = inSInt.GetValue();
        inSInt.SetValue(++value);
        return inSInt;
    }

    public static Sint operator --(Sint inSInt)
    {
        var value = inSInt.GetValue();
        inSInt.SetValue(--value);
        return inSInt;
    }

    public static Sint operator +(Sint left, Sint right)
    {
        return new Sint(left.GetValue() + right.GetValue());
    }
    public static Sint operator +(Sint left, int right)
    {
        return new Sint(left.GetValue() + right);
    }

    public static Sint operator -(Sint left, Sint right)
    {
        return new Sint(left.GetValue() - right.GetValue());
    }

    public static Sint operator -(Sint left, int right)
    {
        return new Sint(left.GetValue() - right);
    }

    public static Sint operator *(Sint left, Sint right)
    {
        return new Sint(left.GetValue() * right.GetValue());
    }

    public static Sint operator *(Sint left, int right)
    {
        return new Sint(left.GetValue() * right);
    }

    public static Sint operator /(Sint left, Sint right)
    {
        return new Sint(left.GetValue() / right.GetValue());
    }

    public static Sint operator /(Sint left, int right)
    {
        return new Sint(left.GetValue() / right);
    }

    public static bool operator ==(Sint s1, Sint s2) { return s1.GetValue() == s2.GetValue(); }
    public static bool operator !=(Sint s1, Sint s2) { return s1.GetValue() != s2.GetValue(); }
    public static bool operator ==(int s1, Sint s2) { return s1 == s2.GetValue(); }
    public static bool operator !=(int s1, Sint s2) { return s1 != s2.GetValue(); }
    public static bool operator ==(Sint s1, int s2) { return s1.GetValue() == s2; }
    public static bool operator !=(Sint s1, int s2) { return s1.GetValue() != s2; }

    public static bool operator <(Sint s1, Sint s2) { return s1.GetValue() < s2.GetValue(); }
    public static bool operator >(Sint s1, Sint s2) { return s1.GetValue() > s2.GetValue(); }
    public static bool operator <(int s1, Sint s2) { return s1 < s2.GetValue(); }
    public static bool operator >(int s1, Sint s2) { return s1 > s2.GetValue(); }
    public static bool operator <(Sint s1, int s2) { return s1.GetValue() < s2; }
    public static bool operator >(Sint s1, int s2) { return s1.GetValue() > s2; }

    public static bool operator <=(Sint s1, Sint s2) { return s1.GetValue() <= s2.GetValue(); }
    public static bool operator >=(Sint s1, Sint s2) { return s1.GetValue() >= s2.GetValue(); }
    public static bool operator <=(int s1, Sint s2) { return s1 <= s2.GetValue(); }
    public static bool operator >=(int s1, Sint s2) { return s1 >= s2.GetValue(); }
    public static bool operator <=(Sint s1, int s2) { return s1.GetValue() <= s2; }
    public static bool operator >=(Sint s1, int s2) { return s1.GetValue() >= s2; }

    public void SetValue(int value)
    {
        _value = value;
        _data = value ^ securityKey;
    }
    private int GetValue()
    {
        int value = _data ^ securityKey;

        if (_value != value)
        {
            AlertGameHacking();
        }

        return value;
    }
    
    public override bool Equals(object o)
    {
        if (o as Sint != null)
            return GetValue() == (o as Sint).GetValue();
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


    public override string ToString()
    {
        return _value.ToString();
    }
}

[System.Serializable]
public class Slong : SecuriyNumber
{
    [SerializeField]
    private long _value; // 보이기 용
    private long _data; // 실제 저장 값

    public Slong(long value)
    {
        SetValue(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator Slong(long value)
    {
        return new Slong(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator long(Slong value)
    {
        return value.GetValue();
    }

    public static Slong operator ++(Slong inSlong)
    {
        var value = inSlong.GetValue();
        inSlong.SetValue(++value);
        return inSlong;
    }

    public static Slong operator --(Slong inSlong)
    {
        var value = inSlong.GetValue();
        inSlong.SetValue(--value);
        return inSlong;
    }

    public static Slong operator +(Slong left, Slong right)
    {
        return new Slong(left.GetValue() + right.GetValue());
    }
    public static Slong operator +(Slong left, int right)
    {
        return new Slong(left.GetValue() + right);
    }

    public static Slong operator -(Slong left, Slong right)
    {
        return new Slong(left.GetValue() - right.GetValue());
    }

    public static Slong operator -(Slong left, long right)
    {
        return new Slong(left.GetValue() - right);
    }

    public static Slong operator *(Slong left, Slong right)
    {
        return new Slong(left.GetValue() * right.GetValue());
    }

    public static Slong operator *(Slong left, long right)
    {
        return new Slong(left.GetValue() * right);
    }

    public static Slong operator /(Slong left, Slong right)
    {
        return new Slong(left.GetValue() / right.GetValue());
    }

    public static Slong operator /(Slong left, long right)
    {
        return new Slong(left.GetValue() / right);
    }

    public static bool operator ==(Slong s1, Slong s2) { return s1.GetValue() == s2.GetValue(); }
    public static bool operator !=(Slong s1, Slong s2) { return s1.GetValue() != s2.GetValue(); }
    public static bool operator ==(long s1, Slong s2) { return s1 == s2.GetValue(); }
    public static bool operator !=(long s1, Slong s2) { return s1 != s2.GetValue(); }
    public static bool operator ==(Slong s1, long s2) { return s1.GetValue() == s2; }
    public static bool operator !=(Slong s1, long s2) { return s1.GetValue() != s2; }

    public static bool operator <(Slong s1, Slong s2) { return s1.GetValue() < s2.GetValue(); }
    public static bool operator >(Slong s1, Slong s2) { return s1.GetValue() > s2.GetValue(); }
    public static bool operator <(long s1, Slong s2) { return s1 < s2.GetValue(); }
    public static bool operator >(long s1, Slong s2) { return s1 > s2.GetValue(); }
    public static bool operator <(Slong s1, long s2) { return s1.GetValue() < s2; }
    public static bool operator >(Slong s1, long s2) { return s1.GetValue() > s2; }

    public static bool operator <=(Slong s1, Slong s2) { return s1.GetValue() <= s2.GetValue(); }
    public static bool operator >=(Slong s1, Slong s2) { return s1.GetValue() >= s2.GetValue(); }
    public static bool operator <=(long s1, Slong s2) { return s1 <= s2.GetValue(); }
    public static bool operator >=(long s1, Slong s2) { return s1 >= s2.GetValue(); }
    public static bool operator <=(Slong s1, long s2) { return s1.GetValue() <= s2; }
    public static bool operator >=(Slong s1, long s2) { return s1.GetValue() >= s2; }

    public void SetValue(long value)
    {
        _value = value;
        _data = value ^ securityKey;
    }
    private long GetValue()
    {
        long value = _data ^ securityKey;

        if (_value != value)
        {
            AlertGameHacking();
        }

        return value;
    }

    public override string ToString()
    {
        return _value.ToString();
    }
    
    public override bool Equals(object o)
    {
        if (o as Slong != null)
            return GetValue() == (o as Slong).GetValue();
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}

[System.Serializable]
public class Sfloat : SecuriyNumber
{
    [SerializeField]
    private float _value; // 보이기 용
    private float _valueTemp; // 계산용
    private int _data; // 실제 저장 값
    private int _dataTemp; // 계산용


    public Sfloat(float value)
    {
        SetValue(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator Sfloat(float value)
    {
        return new Sfloat(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator float(Sfloat value)
    {
        return value.GetValue();
    }

    public static Sfloat operator +(Sfloat left, Sfloat right)
    {
        return new Sfloat(left.GetValue() + right.GetValue());
    }
    public static Sfloat operator +(Sfloat left, float right)
    {
        return new Sfloat(left.GetValue() + right);
    }

    public static Sfloat operator -(Sfloat left, Sfloat right)
    {
        return new Sfloat(left.GetValue() - right.GetValue());
    }

    public static Sfloat operator -(Sfloat left, float right)
    {
        return new Sfloat(left.GetValue() - right);
    }

    public static Sfloat operator *(Sfloat left, Sfloat right)
    {
        return new Sfloat(left.GetValue() * right.GetValue());
    }

    public static Sfloat operator *(Sfloat left, int right)
    {
        return new Sfloat(left.GetValue() * right);
    }

    public static Sfloat operator *(Sfloat left, float right)
    {
        return new Sfloat(left.GetValue() * right);
    }

    public static Sfloat operator /(Sfloat left, Sfloat right)
    {
        return new Sfloat(left.GetValue() / right.GetValue());
    }

    public static Sfloat operator /(Sfloat left, int right)
    {
        return new Sfloat(left.GetValue() / right);
    }

    public static Sfloat operator /(Sfloat left, float right)
    {
        return new Sfloat(left.GetValue() / right);
    }
        
    public static bool operator ==(Sfloat s1, Sfloat s2) { return s1.GetValue() == s2.GetValue(); }
    public static bool operator !=(Sfloat s1, Sfloat s2) { return s1.GetValue() != s2.GetValue(); }
    public static bool operator ==(float s1, Sfloat s2) { return s1 == s2.GetValue(); }
    public static bool operator !=(float s1, Sfloat s2) { return s1 != s2.GetValue(); }
    public static bool operator ==(Sfloat s1, float s2) { return s1.GetValue() == s2; }
    public static bool operator !=(Sfloat s1, float s2) { return s1.GetValue() != s2; }

    public static bool operator <(Sfloat s1, Sfloat s2) { return s1.GetValue() < s2.GetValue(); }
    public static bool operator >(Sfloat s1, Sfloat s2) { return s1.GetValue() > s2.GetValue(); }
    public static bool operator <(float s1, Sfloat s2) { return s1 < s2.GetValue(); }
    public static bool operator >(float s1, Sfloat s2) { return s1 > s2.GetValue(); }
    public static bool operator <(Sfloat s1, float s2) { return s1.GetValue() < s2; }
    public static bool operator >(Sfloat s1, float s2) { return s1.GetValue() > s2; }

    public static bool operator <=(Sfloat s1, Sfloat s2) { return s1.GetValue() <= s2.GetValue(); }
    public static bool operator >=(Sfloat s1, Sfloat s2) { return s1.GetValue() >= s2.GetValue(); }
    public static bool operator <=(float s1, Sfloat s2) { return s1 <= s2.GetValue(); }
    public static bool operator >=(float s1, Sfloat s2) { return s1 >= s2.GetValue(); }
    public static bool operator <=(Sfloat s1, float s2) { return s1.GetValue() <= s2; }
    public static bool operator >=(Sfloat s1, float s2) { return s1.GetValue() >= s2; }

    public void SetValue(float value)
    {
        _value = value;
        _dataTemp = System.BitConverter.ToInt32(System.BitConverter.GetBytes(value), 0); ;
        _data = _dataTemp ^ securityKey;
    }

    private float GetValue()
    {
        _dataTemp = _data ^ securityKey;
        _valueTemp = System.BitConverter.ToSingle(System.BitConverter.GetBytes(_dataTemp), 0);
        if (_valueTemp != _value)
        {
            AlertGameHacking();
        }
        return _valueTemp;
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    public override bool Equals(object o)
    {
        if (o as Sfloat != null)
            return GetValue() == (o as Sfloat).GetValue();
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

}
[System.Serializable]
public class Sbool : SecuriyNumber
{
    [SerializeField]
    private int _value; // 보이기 용
    private bool _valueTemp; // 계산용
    private int _data; // 실제 저장 값

    public Sbool()
    {
        _value = 0;
        _data = 0 ^ securityKey;
    }

    public Sbool(bool value)
    {
        SetValue(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator Sbool(bool value)
    {
        return new Sbool(value);
    }

    //묵시적 형변환 오버로딩
    public static implicit operator bool(Sbool value)
    {
        return value.GetValue();
    }

    public static Sbool operator !(Sbool value)
    {
        return new Sbool(!value.GetValue());
    }

    // Definitely true operator. Returns true if the operand is 
    // dbTrue, false otherwise:
    public static bool operator true(Sbool value)
    {
        return value.GetValue() == true;
    }

    // Definitely false operator. Returns true if the operand is 
    // dbFalse, false otherwise:
    public static bool operator false(Sbool value)
    {
        return value.GetValue() == false;
    }

    public static readonly Sbool sbFalse = new Sbool(false);
    public static readonly Sbool sbTrue = new Sbool(true);

    public void SetValue(bool value)
    {
        _value = value ? 1 : 0;
        _data = _value ^ securityKey;
    }
    private bool GetValue()
    {
        _valueTemp = ((_data ^ securityKey) == 1 ? true : false);
        if (_valueTemp != (_value == 1 ? true : false))
        {
            AlertGameHacking();
        }
        return _valueTemp;
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}

/*
public class SecuriyNumberTest : MonoBehaviour
{
    public UnityEngine.UI.Text lblSint;
    public UnityEngine.UI.Text lblSfloat;
    public UnityEngine.UI.Text lblSbool;

    Sint sintValue = new Sint(10);
    Sfloat sfloatValue = new Sfloat(10.10f);
    Sbool sboolValue = new Sbool(false);

    void SintTest()
    {
        lblSint.text = "";
        lblSint.text += string.Format("Sint {0}", (int)sintValue);
        sintValue++;
        lblSint.text += string.Format("\nSint ++ {0}", (int)sintValue);
        sintValue--;
        lblSint.text += string.Format("\nSint -- {0}", (int)sintValue);
        sintValue = sintValue + 1;
        lblSint.text += string.Format("\nSint +1 {0}", (int)sintValue);
        int intTemp = sintValue + 1;
        lblSint.text += string.Format("\nSint +1 {0}", intTemp);

        sintValue.SetValue(50);
        lblSint.text += string.Format("\nSint = 50 {0}", (int)sintValue);
        int temp = sintValue;
        lblSint.text += string.Format("\nSint {0}", temp);
    }

    void SfloatTest()
    {
        lblSfloat.text = "";
        lblSfloat.text = string.Format("float : {0}", (float)sfloatValue);
        sfloatValue = sfloatValue * 10.0f;
        lblSfloat.text += string.Format("\n * 10 : {0}", (float)sfloatValue);
        sfloatValue = sfloatValue / 10.0f;
        lblSfloat.text += string.Format("\n{0} / 10 :  {0} ", (float)sfloatValue);
        sfloatValue = sfloatValue + 10.5f;
        lblSfloat.text += string.Format("\n + 10.5 : {0}", (float)sfloatValue);
        sfloatValue = sfloatValue - 10.5f;
        lblSfloat.text += string.Format("\n - 10.5 : {0}", (float)sfloatValue);
    }

    void SboolTest()
    {
        lblSbool.text = "";


        if (sboolValue)
        {
            lblSbool.text += string.Format("bool : true");
        }
        if (!sboolValue)
        {
            lblSbool.text += string.Format("bool : false");
        }
        sboolValue = Sbool.sbFalse;
    }

    void Start()
    {
        SintTest();
        SfloatTest();
        SboolTest();
    }

}
*/