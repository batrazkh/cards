using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    //private int[] cardTypes;
    [SerializeField] public int[] cardTypesIn;

    [SerializeField] public Card[] cards;
    [SerializeField] private Text scoreText;
    [SerializeField] private int score = 0;

    private Card firstCard;
    private Card secondCard;
    private void OnEnable()
    {
        setScoreText(score);
        fillCardsIn();
        shuffleCards();
       // setCardType();
        foreach (Card card in cards)
        {
            card.Start();
            card.showCard();
        }
    }

    private void Start()
    {
        
        StartCoroutine(WaitForSeconds());
    }

    public void onRestartClicked()
    {
        
        fillCardsIn();
        shuffleCards();
       // setCardType();
        foreach (Card card in cards)
        {
            card.setDefaultImage();
            card.Start();
            card.showCard();
            StartCoroutine(WaitForSeconds());
        }
    }

    private void setCardType()
    {
        foreach (Card card in cards)
        {
            int i = card.cardId; 
            card.cardType = cardTypesIn[i];
            //Debug.Log(cardTypesIn.Length);
        }
    }

    private void fillCardsIn()
    {
        System.Random rand = new System.Random();
        List<int> tempList = new List<int>();
        while (tempList.Capacity < 6)
        {
            int j = rand.Next(0, 53);
            if (!tempList.Contains(j))
            {
                tempList.Add(j);
            }
        }
        for (int i = 0; i < 5; ++i)
        {
            cardTypesIn[i] = tempList[i];
            cardTypesIn[i + 5] = tempList[i];
        }


    }

    private void shuffleCards()
    {
        System.Random rnd = new System.Random();
        for (int i= cardTypesIn.Length-1; i>=1; i--)
        {
            int j = rnd.Next(i + 1);
            int tmp = cardTypesIn[j];
            cardTypesIn[j] = cardTypesIn[i];
            cardTypesIn[i] = tmp;
        }
        //cardTypes = cardTypesIn;
        //foreach (int a in cardTypes)
        //{
        //   // Debug.Log(cardTypes[a]);
        //}
        setCardType();
    }

    private void setScoreText(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void guess(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }else if(secondCard == null)
        {
            secondCard = card;
            check();
        }
        else
        {
            firstCard.setDefaultImage();
            secondCard.setDefaultImage();
            firstCard = null;
            secondCard = null;
            guess(card);
        }
    }
    private void check()
    {
        if (firstCard.cardType == secondCard.cardType)
        {
            score++;
            firstCard = null;
            secondCard = null;
            setScoreText(score);
        }
        else
        {
            score--;
            setScoreText(score);
        }
    }
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(2);
        foreach (Card card in cards)
        {
            card.setDefaultImage();
        }
    }
}
