using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private GameObject _Camera;

    [SerializeField]
    private GameObject _Player;

    public TextMeshProUGUI textComponent;
    public List<string> lines;
    public float textSpeed;

    private int index; //На каком мы моменте диалога

    void Start()
    {
        textComponent.text = string.Empty;
    }

    void Update()
    {
        if (gameObject.activeSelf && Input.GetMouseButtonDown(0))
        {
            
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        StopAllCoroutines();
        textComponent.text = string.Empty;
        index = 0;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Символы печатаются по одному
        yield return new WaitForSeconds(textSpeed*2);
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _Player.GetComponent<MyCharacterController>().isActivate = true;
            CameraTracking _CameraTrack = _Camera.GetComponent<CameraTracking>();
            _CameraTrack.isTrackingActivate = true;
            _CameraTrack.isTrackingPlayer = true;
            gameObject.SetActive(false);
        }
    }
}
