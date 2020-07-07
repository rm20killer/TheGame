using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class gunShot : MonoBehaviour
{
    public float Range = 100f;

    public GameObject impactEffect;
    private RaycastHit hit;
    private Ray ray;
    #region var
    private int firetime = 2;
    public int bullets = 6;
    public int damage = 10;
    public int maxbullets = 6;
    #endregion
    //public Text BulletText;
    //Text instructions;



    // Start is called before the first frame update
    void Start()
    {
       // instructions = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        if (Input.GetMouseButtonDown(0))
        {
            if (bullets >=1)
            {
                bullets -= 1;
                         
                //firetime = 0;
                if (Physics.Raycast(ray, out hit, Range))
                {
                    GameObject impactEffectGO = Instantiate(impactEffect, hit.point, Quaternion.identity) as GameObject;
                    Destroy(impactEffectGO, 2);
                    if (hit.transform.gameObject.tag == "enemy")
                    {
                        Debug.Log("enermy hit");
                        //damage(); //deal damage to enermy
                    }
                }
                
            }
            else
            {
                Debug.Log("no bullets");
            }
        }
    }
}
