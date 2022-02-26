using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public static uiManager uiManagerS;
    [Header("Ui Manager Values")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Text rankText;
}
