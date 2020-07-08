using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class gunShot : MonoBehaviour
{
    public float Range = 100f;

    public GameObject impactEffect;
    private RaycastHit hit;
    private Ray ray;
    #region var
    private int firerate = 15;
    public int bullets = 6;
    public int damage = 10;
    public int maxbullets = 6;
    private int hitforce = 10;
    #endregion
    //public Text BulletText;
    //Text instructions;

    private float nexttimetofire = 0;

    // Start is called before the first frame update
    void Start()
    {
       // instructions = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        //autofire
        //if (Input.GetButton("fire1") && Time.time>=nexttimetofire)
        //tap fire
        if (Input.GetMouseButtonDown(0) && Time.time>=nexttimetofire)
        {
            nexttimetofire = Time.time + 1f / firerate;

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
                        Target target = hit.transform.GetComponent<Target>();
                        if (target != null)
                        {
                            target.AIDamgeTaken(damage);
                        }
                        Debug.Log("enermy hit");
                        if (hit.rigidbody != null)
                        {
                            hit.rigidbody.AddForce(-hit.normal * hitforce);
                        }
                        
                        //damage(); //deal damage to enermy
                    }
                }
                
            }
            else
            {
                Debug.Log("no bullets");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //reload animation
            bullets = 6;
        }
    }
}
