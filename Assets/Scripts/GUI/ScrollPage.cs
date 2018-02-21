using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollPage : MonoBehaviour {

    private int numberPage;

    [SerializeField]
    private int numberOfPages;
    // Use this for initialization
    void Start () {
        numberPage = 1;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void AddNumber()
    {
        if (numberPage < numberOfPages)
            numberPage++;
    }
    public void DecreaseNumber()
    {
        if (numberPage > 1)
            numberPage--;
    }
    public int GetPageNumber()
    {
        return numberPage;
    }
    public void SetPageNumber(int value)
    {
        numberPage = value;
    }
}
