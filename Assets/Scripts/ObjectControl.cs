using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectControl : MonoBehaviour {
    /// <summary>
    /// control the objects cut
    /// </summary>
    /// 
    //used for cutting parts of the fruit
    public GameObject[] half_fruits;
    //effects
    public GameObject splash_effect;
    public GameObject splash_flat_effect;

    public AudioClip cut_sound;

    private bool isCut = false;

    public void OnCut()
    {
        if (isCut)
        {
            return;
        }

        if (gameObject.name.Contains("Bomb"))
        {
            Instantiate<GameObject>(splash_effect, transform.position, Quaternion.identity);
            //stop boom sound
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            for (int i = 0; i < half_fruits.Length; i++)
            {
                GameObject go = Instantiate<GameObject>(half_fruits[i], transform.position, Random.rotation);
                go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5f, ForceMode.Impulse);
            }
            //generate effects
            Instantiate<GameObject>(splash_effect, transform.position, Quaternion.identity);
            Instantiate<GameObject>(splash_flat_effect, transform.position, Quaternion.identity);
        }

        //destory current ojbects
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(cut_sound,transform.position);
        isCut = true;
    }
}
