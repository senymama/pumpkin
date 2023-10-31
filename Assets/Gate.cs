using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public List<string> options; // Список вариантов
    public int selectedIndex = 0; // Индекс выбранного варианта

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
            dialogue.lines = new List<string> { "Ты уверен что готов сделать предположение кто тебя убил?", "Используй стрелку вверх и стрелку вниз для выбора", "Сделал выбор? Жми энтер" };
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
        Debug.Log("Выбран вариант: " + selectedOption);

        yield return new WaitForSeconds(8f);

        player.Stop();

        image.sprite = openedGate;

        yield return new WaitForSeconds(0.5f);

        _Player.GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(1.0f);

        _SpriteRenderer.enabled = true;

        if (selectedIndex == 0)
        { // Отец Брауна

            dialogue.lines = new List<string> { "?????: я понимаю, что он выглядит устрашающе, но ядом люди такого темперамента не убивают" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();

        }
        else if (selectedIndex == 1) // Том
        {
            dialogue.lines = new List<string> { "?????: разве вы не лучшие друзья? мда.... искупи свою вину вечным созиданием" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();

        }
        else if (selectedIndex == 2) // Бетси
        {
            dialogue.lines = new List<string> { "?????: глупенький малыш, как ты вообще мог подумать, что тебя убило такое прекрасное создание" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 3) // Родители Бетти
        {
            dialogue.lines = new List<string> { "?????: ты походу вообще не попытался разобраться? в наказание, малыш, подумай еще тут хотя бы пару....", "?????: тысячелетий" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 4) // Джир
        {
            dialogue.lines = new List<string> { "?????: да, любой бы подумал на него, но на самом деле не такой уж он и плохой этот старик. Просто жизненные обстоятельства...Тебя он не трогал." };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 5) //Родители Соула
        {
            dialogue.lines = new List<string> { "?????: да, ты прав, тебя убили собственные родители", "?????: А все почему? ТВОЙ ОТЕЦ СЛАБАК, вместо того чтобы выбраться из долгов своими силами, он застраховал твою жизнь и спустя месяц отравил.", "?????: жаль, но тебе доступна дверь в счастье...", "?????: удачи..." };
            _SpriteRenderer.color = Color.gray;
            dialogue.StartDialogue();
        }
        else if (selectedIndex == 6) // Детектив
        {
            dialogue.lines = new List<string> { "?????: ты походу вообще не попытался разобраться? в наказание, малыш, подумай еще тут хотя бы пару....", "?????: тысячелетий" };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();
        }
    }
}
/**/
/*dialogue.lines = new List<string> { "?????: глупенький малыш, разве тебе не сказали что попытка была одна?",  };
            _SpriteRenderer.color = Color.black;
            dialogue.StartDialogue();*/
