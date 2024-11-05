using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpriteSelector : MonoBehaviour
{
    public Sprite spU, spD, spR, spL, spUD, spRL, spUR, spUL, spDR, spDL, spULD, spRUL, spDRU, spLDR, spUDRL;
    public GameObject GU, GD, GR, GL, GUD, GRL, GUR, GUL, GDR, GDL, GULD, GRUL, GDRU, GLDR, GUDRL;
    public bool up, down, left, right;
    public int type;
    public Color normalColor, enterColor;
    Color mainColor;
    SpriteRenderer rend;
    LevelGeneration generator;
    Transform grid;
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
       
        mainColor = normalColor;
        PickSprite();
        PickColor();
        grid = transform.parent;
        SpawnWalls();

    }
    void PickSprite()
    { //picks correct sprite based on the four door bools
        if (up)
        {
            if (down)
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spUDRL;
                    }
                    else
                    {
                        rend.sprite = spDRU;
                    }
                }
                else if (left)
                {
                    rend.sprite = spULD;
                }
                else
                {
                    rend.sprite = spUD;
                }
            }
            else
            {
                if (right)
                {
                    if (left)
                    {
                        rend.sprite = spRUL;
                    }
                    else
                    {
                        rend.sprite = spUR;
                    }
                }
                else if (left)
                {
                    rend.sprite = spUL;
                }
                else
                {
                    rend.sprite = spU;
                }
            }
            return;
        }
        if (down)
        {
            if (right)
            {
                if (left)
                {
                    rend.sprite = spLDR;
                }
                else
                {
                    rend.sprite = spDR;
                }
            }
            else if (left)
            {
                rend.sprite = spDL;
            }
            else
            {
                rend.sprite = spD;
            }
            return;
        }
        if (right)
        {
            if (left)
            {
                rend.sprite = spRL;
            }
            else
            {
                rend.sprite = spR;
            }
        }
        else
        {
            rend.sprite = spL;
        }
    }

    void PickColor()
    {
        if (type == 0)
        {
            mainColor = normalColor;
        }
        else if (type == 1)
        {
            mainColor = enterColor;
        }
        rend.color = mainColor;
    }
    void SpawnWalls()
    {
        GameObject a = null;
        if (rend.sprite == spU)
        {
           a = Instantiate(GU, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spD)
        {
            a = Instantiate(GD, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spR)
        {
           a= Instantiate(GR, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spL)
        {
           a= Instantiate(GL, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spUD)
        {
           a= Instantiate(GUD, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spRL)
        {
           a= Instantiate(GRL, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spUR)
        {
           a= Instantiate(GUR, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spUL)
        {
           a= Instantiate(GUL, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spDR)
        {
           a= Instantiate(GDR, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spDL)
        {
           a= Instantiate(GDL, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spULD)
        {
           a= Instantiate(GULD, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spRUL)
        {
           a= Instantiate(GRUL, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spDRU)
        {
           a= Instantiate(GDRU, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spLDR)
        {
            a= Instantiate(GLDR, transform.position, Quaternion.identity);
        }
        if (rend.sprite == spUDRL)
        {
           a= Instantiate(GUDRL, transform.position, Quaternion.identity);
        }
        a.transform.parent = grid;
    }
}
