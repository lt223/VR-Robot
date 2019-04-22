using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BoneController : MonoBehaviour
{
    public Vector3  Initpos;

    private Vector3 nowPos;

    public InputField inputxText;
    public InputField inputyText;
    public InputField inputzText;

    public Transform jiazi1;

    public Transform jiazi2;

    public Text speedupText;

    public bool isLeftXDown { get; set; }

    public bool isRightXDown { get; set; }

    public bool isLeftYDown { get; set; }

    public bool isRightYDown { get; set; }

    public bool isLeftZDown { get; set; }

    public bool isRightZDown { get; set; }
    
    private float initSpeed = 10;

    private float nowSpeed;

    private int speedscale;

    private void Update()
    {
        Vector3 pos = nowPos;
        if (isLeftXDown)
        {
            pos.x -= nowSpeed * Time.deltaTime;
        }
        else if (isRightXDown)
        {
            pos.x += nowSpeed * Time.deltaTime;
        }
        else if (isLeftYDown)
        {
            pos.y -= nowSpeed * Time.deltaTime;
        }
        else if (isRightYDown)
        {
            pos.y += nowSpeed * Time.deltaTime;
        }
        else if (isLeftZDown)
        {
            pos.z -= nowSpeed * Time.deltaTime;
        }
        else if (isRightZDown)
        {
            pos.z += nowSpeed * Time.deltaTime;
        }
        if (pos.x > 12)
            pos.x = 12;
        else if (pos.x < 4)
            pos.x = 4;
        if (pos.z > 12)
            pos.z= 12;
        else if (pos.z < 4)
            pos.z = 4;
        if (pos.y > 4)
            pos.y = 4;
        else if (pos.y < -4)
            pos.y = -4;
        nowPos = pos;
        inputxText.text = nowPos.x.ToString("#0.00");
        inputyText.text = nowPos.y.ToString("#0.00");
        inputzText.text = nowPos.z.ToString("#0.00");
    }

    void Start()
    {
        nowSpeed = initSpeed;
        inputxText.onEndEdit.AddListener(OnXEditEnd);
        inputyText.onEndEdit.AddListener(OnYEditEnd);
        inputzText.onEndEdit.AddListener(OnZEditEnd);
        nowPos = Initpos;
        Vector3 pos = Initpos;
        inputxText.text = pos.x.ToString("#0.00");
        inputyText.text = pos.y.ToString("#0.00");
        inputzText.text = pos.z.ToString("#0.00");
    }

    public void OnXEditEnd(string text)
    {
        float data;
        Vector3 pos = nowPos;
        if (float.TryParse(text,out data))
        {
            if (data > 12)
                data = 12;
            if (data < 4)
                data = 4;
            pos.x = data;
            nowPos = pos;
            inputxText.text = data.ToString("#0.00");
        }
        else
        {
            inputxText.text = pos.x.ToString("#0.00");
        }
    }

    public void OnYEditEnd(string text)
    {
        float data;
        Vector3 pos = nowPos;
        if (float.TryParse(text, out data))
        {
            if (data > 4)
                data = 4;
            if (data < -4)
                data = -4;
            pos.y = data;
            nowPos = pos;
            inputyText.text = data.ToString("#0.00");
        }
        else
        {
            inputyText.text = pos.y.ToString("#0.00");
        }
    }

    public void OnZEditEnd(string text)
    {
        float data;
        Vector3 pos = nowPos;
        if (float.TryParse(text, out data))
        {
            if (data > 12)
                data = 12;
            if (data < 4)
                data = 4;
            pos.z = data;
            nowPos = pos;
            inputzText.text = data.ToString("#0.00");
        }
        else
        {
            inputzText.text = pos.z.ToString("#0.00");
        }
    }

    public void Reset()
    {
        nowPos = Initpos;
        inputxText.text = nowPos.x.ToString("#0.00");
        inputyText.text = nowPos.y.ToString("#0.00");
        inputzText.text = nowPos.z.ToString("#0.00");
    }

    public void SpeedAdd()
    {
        nowSpeed *= 1.2f;
        speedscale += 20;
        speedupText.text = speedscale + "%";
    }

    public void SpeedReduse()
    {
        nowSpeed /= 1.2f;
        speedscale -= 20;
        speedupText.text = speedscale + "%";
    }

    public void Catch()
    {
        jiazi1.localEulerAngles = new Vector3(0, 90, 0);
        jiazi2.localEulerAngles = new Vector3(0, 90, 0);
    }


    public void Release()
    {
        jiazi1.localEulerAngles = new Vector3(0, 120, 0);
        jiazi2.localEulerAngles = new Vector3(0, 60, 0);
    }
}
