using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCounter : MonoBehaviour
{
    public Text TrashPickUp;

    public Text BombPickUp;

    [SerializeField]
    public GameObject player;

    private PickUpController pickup;

    void Start()
    {
        TrashPickUp = GetComponent<Text>();
       
        pickup = player.GetComponent<PickUpController>();
    }

    void Update()
    {

       TrashPickUp.text = "Trash " + pickup.currentAmount;
       BombPickUp.text = "Bombs " + pickup.currentBombs;
    }

}
