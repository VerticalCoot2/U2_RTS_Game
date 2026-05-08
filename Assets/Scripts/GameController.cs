using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public int gold;
    [SerializeField] TMP_Text goldText;

    public Transform alliesGroup;
    [SerializeField] TMP_Text alliesLeftText;

    public Transform enemiesGroup;
    [SerializeField] TMP_Text enemiesLeftText;

    private void Awake()
    {
        gold = 500;
    }


    void Start()
    {
        StartCoroutine(GetGold());
    }

    // Update is called once per frame
    void Update()
    {
        alliesLeftText.text = $"Allies left: {alliesGroup.childCount}";
        enemiesLeftText.text = $"Enemies left: {enemiesGroup.childCount}";
    }
    
    public void GoldTextUpdate()
    {
        goldText.text = $"Gold: {gold}";
    }

    IEnumerator GetGold()
    {
        while (true)
        {
            GoldTextUpdate();
            yield return new WaitForSeconds(5);
            gold += 500;
        }
    }
}
