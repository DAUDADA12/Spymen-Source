using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider HealthBar;
    public TMP_Text ChancesText;
    public GameObject ConfirmationPopUp;
    public TMP_Text ConfirmationText;
    [TextArea(3,10)]public string RestartConfirmationText;

    void Start()
    {
        HealthBar.maxValue = InstanceManager.Instance.MaxHealth;
        HealthBar.minValue = 0;
        ChancesText.text = "Chances: "+InstanceManager.Instance.Chances.ToString();
        if(InstanceManager.Instance.Chances == 0)
        {
            GetComponent<UIBlendPanel>().Ready = false;
        }
    }

    public void Home()
    {
        Destroy(InstanceManager.Instance);
    }

    public void Yes()
    {
        InstanceManager.Instance.ClearKey();
        InstanceManager.Instance.ClearPosition();
        InstanceManager.Instance.HP = InstanceManager.Instance.Stored_HP;
        InstanceManager.Instance.Chances = InstanceManager.Instance.Stored_Chances;
    }

    public void No()
    {
        ConfirmationPopUp.SetActive(false);
    }

    public void StartOver()
    {
        if(ConfirmationText != null)
        {
            ConfirmationText.text = RestartConfirmationText;
            ConfirmationPopUp.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        HealthBar.value = InstanceManager.Instance.GetHealthInfo();
    }
}
