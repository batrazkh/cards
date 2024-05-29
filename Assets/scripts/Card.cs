using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Sprite[] cardContent;
    [SerializeField] private Sprite cardBack;
    [SerializeField] public int cardId;

    public int cardType = 2;
    private Image cardImage;
    private GamePlay gamePlay;

    public void Start()
    {
        gamePlay = FindObjectOfType<GamePlay>();
      //  cardType = this.cardId;
        cardImage = GetComponent<Image>();
        showCard();
    }
    public void onClick()
    {
        if (cardImage.sprite.Equals(cardBack))
        {
            cardImage.sprite = cardContent[cardType];
            gamePlay.guess(this);
        }
    }
    public void setDefaultImage()
    {
        cardImage.sprite = cardBack;
    }
    
    public void showCard()
    {
        if (cardImage.sprite.Equals(cardBack))
        {
            if (cardContent[cardType]!=null)
            {
                Debug.Log(this.name);
                cardImage.sprite = cardContent[cardType];
            }
        }
    }
    private void hideCard()
    {
        cardImage.sprite = cardBack;
    }
}