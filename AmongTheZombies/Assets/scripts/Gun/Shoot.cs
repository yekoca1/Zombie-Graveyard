using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera camera;
    public int range;
    [Header("Gun Damage On Hit")]
    public int damage;

    public GameObject bloodPrefab;
    public GameObject decal;
    private int bullet = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(bullet > 0)
            {
                fire();
                bullet--;
                Debug.Log("kalan mermi :" + bullet);
            }
            else{
                Debug.Log("mermi bitti!");
            }
            
        }
    }

    public void fire()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))  // kameranın pozisyonundan ileri yöne doğru bir raycast yolla, çarparsa hit değişkeninde tut, mesafe
        {
            if(hit.transform.tag == "zombi")
            {
                hit.transform.GetComponent<zombieHealth>().Hit(damage);
                GenerateBloodEffect(hit);
            }
            else
            {
                GenerateHitEffect(hit);
            }
        }
    }

    public void reload()
    {
        bullet = 20;
    }

    public int getBullet()
    {
        return bullet;
    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
        //Debug.Log("Kanama oluştu");
    }

    private void GenerateHitEffect(RaycastHit hit)
    {
        GameObject hitObject = Instantiate(decal, hit.point, Quaternion.identity);  //burada rotasyon önemli
        hitObject.transform.rotation = Quaternion.FromToRotation(decal.transform.forward*-1, hit.normal);
        //Debug.Log("hasar oluştu");
    }
}
