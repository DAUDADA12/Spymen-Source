using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TMP_Text DialogueText;
    public UIBlendPanel BlendPanel;
    public GameObject DialogueBox;
    public Text NameText;
    [SerializeField]private int CurrentDialogue;
    [TextArea(3,10)]
    public string[] Dialogues;
    public string[] Name;
    public GameObject[] Profile;

    void Start() 
    {
        CurrentDialogue = 0;
        if(CurrentDialogue < Dialogues.Length)
        {
            DialogueText.text = Dialogues[CurrentDialogue];
            NameText.text = Name[CurrentDialogue];
            for(int i = 0; i < Profile.Length; i++)
            {
                if(i != CurrentDialogue)
                    Profile[i].SetActive(false);
                else
                {
                    Profile[CurrentDialogue].SetActive(true);
                    break;
                }
            }
        }
    }

    public void Continue()
    {
        if(CurrentDialogue < Dialogues.Length - 1)
        {
            CurrentDialogue++;
            DialogueText.text = Dialogues[CurrentDialogue];
            NameText.text = Name[CurrentDialogue];
            for(int i = 0; i < Profile.Length; i++)
            {
                if(i != CurrentDialogue)
                    Profile[i].SetActive(false);
                else
                {
                    Profile[CurrentDialogue].SetActive(true);
                    break;
                }
            }
        }
        else
        {
            DialogueBox.SetActive(false);
            BlendPanel.Ready = false;
        }
    }
}
