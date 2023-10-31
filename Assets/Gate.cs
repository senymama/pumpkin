using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public List<string> options; // ������ ���������
    public int selectedIndex = 0; // ������ ���������� ��������

    public TextMeshProUGUI text;

    [SerializeField]
    private GameObject _Player;
    private MyCharacterController _PlayerController;

    [SerializeField]
    private GameObject _Image;
    private SpriteRenderer _SpriteRenderer;

    public Dialogue dialogue;

    public SpriteRenderer image;

    public Sprite openedGate;

    public AudioSource player;
    public AudioClip sound;

    private void Start()
    {
        text.text = string.Empty;

        _PlayerController = _Player.GetComponent<MyCharacterController>();

        _SpriteRenderer = _Image.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialogue.lines = new List<string> { "�� ������ ��� ����� ������� ������������� ��� ���� ����?", "��������� ������� ����� � ������� ���� ��� ������", "������ �����? ��� �����" };
            dialogue.StartDialogue();
            _PlayerController.isActivate = false;
            _PlayerController.StopMove();
            StartCoroutine(selsct());
        }
    }

    IEnumerator selsct()
    {
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            _PlayerController.isActivate = false;
            _PlayerController.StopMove();
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedIndex--;
                if (selectedIndex < 0)
                {
                    selectedIndex = options.Count - 1;
                }

                text.text = options[selectedIndex].ToString();
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedIndex++;
                if (selectedIndex >= options.Count)
                {
                    selectedIndex = 0;
                }
                text.text = options[selectedIndex].ToString();
            }
            yield return null;
        }
        player.clip = sound;
        player.Play();

        string selectedOption = options[selectedIndex];
        Debug.Log("������ �������: " + selectedOption);

        yield return new WaitForSeconds(8f);

        player.Stop();

        image.sprite = openedGate;

        yield return new WaitForSeconds(0.5f);

        _Player.GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(1.0f);

        _SpriteRenderer.enabled = true;

        if (selectedIndex == 0)
        { // ���� ������

            dialogue.lines = new List<string> { "?????: � �������, ��� �� �������� ����������, �� ���� ���� ������ ������������ �� �������" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();

        }
        else if (selectedIndex == 1) // ���
        {
            dialogue.lines = new List<string> { "?????: ����� �� �� ������ ������? ���.... ������ ���� ���� ������ ����������" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();

        }
        else if (selectedIndex == 2) // �����
        {
            dialogue.lines = new List<string> { "?????: ���������� �����, ��� �� ������ ��� ��������, ��� ���� ����� ����� ���������� ��������" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 3) // �������� �����
        {
            dialogue.lines = new List<string> { "?????: �� ������ ������ �� ��������� �����������? � ���������, �����, ������� ��� ��� ���� �� ����....", "?????: �����������" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 4) // ����
        {
            dialogue.lines = new List<string> { "?????: ��, ����� �� ������� �� ����, �� �� ����� ���� �� ����� �� �� � ������ ���� ������. ������ ��������� ��������������...���� �� �� ������." };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 5) //�������� �����
        {
            dialogue.lines = new List<string> { "?????: ��, �� ����, ���� ����� ����������� ��������", "?????: � ��� ������? ���� ���� ������, ������ ���� ����� ��������� �� ������ ������ ������, �� ����������� ���� ����� � ������ ����� �������.", "?????: ����, �� ���� �������� ����� � �������...", "?????: �����..." };
            _SpriteRenderer.color = Color.gray;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 6) // ��������
        {
            dialogue.lines = new List<string> { "?????: �� ������ ������ �� ��������� �����������? � ���������, �����, ������� ��� ��� ���� �� ����....", "?????: �����������" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
    }
}
/**/
/*dialogue.lines = new List<string> { "?????: ���������� �����, ����� ���� �� ������� ��� ������� ���� ����?",  };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();*/
