using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    void Awake() => instance = this;

    public TextMeshProUGUI m_Input;
    public Button m_ConnectBtn;

    public GameObject m_cPlayerPenal;
    public GameObject GamePenal;

    public TextMeshProUGUI m_UserNameTxt;
    private void Start()
    {
        m_ConnectBtn.onClick.AddListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        //Debug.Log(m_Input.text);
    }

    public void OnConnectSuccess(bool i_check,string n_name)
    {
        m_cPlayerPenal.SetActive(!i_check);
        GamePenal.SetActive(i_check);
        m_UserNameTxt.text = n_name;
    }
}
