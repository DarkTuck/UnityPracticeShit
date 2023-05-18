using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColrSetter : MonoBehaviour
{
    public int team;
    SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        SetTeamColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetTeamColor()
    {
        if(team == 1)
        {
            rend.color = Color.blue;
        }
        else if(team == 2)
        {
            rend.color = Color.red;
        }
        else
        {
            rend.color = Color.gray;
        }
    }

    public void SwitchColor()
    {
        if (rend.color == Color.red)
        {
            rend.color = Color.green;
        }
        else if (rend.color == Color.green)
        {
            rend.color = Color.red;
        }
        else
        {
            rend.color = Color.red;
        }
    }
}
