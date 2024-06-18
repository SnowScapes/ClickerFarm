using System;
using UnityEngine;
using UnityEngine.UI;

public class CropFillUI : MonoBehaviour
{
    [SerializeField] private Image CropProgress;
    [SerializeField] private Playerstat stat;
    private CropSystem crop;

    private void Awake()
    {
        stat = GameManager.Instance.stat;
        crop = GameManager.Instance.Crop.GetComponent<CropSystem>();
        crop.ClickEvent += SetShotFill;
    }

    public void SetShotFill(float value)
    {
        CropProgress.fillAmount = CropProgress.fillAmount >= 1 ? 0 : CropProgress.fillAmount + (value / stat.Max);
    }
}
