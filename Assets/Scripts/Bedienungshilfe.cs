using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedienungshilfe : MonoBehaviour
{
    [SerializeField] private GameObject _bedienungshilfeMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMenu()
    {
        _bedienungshilfeMenu.SetActive(true);
    }

    public void closeMenu()
    {
        _bedienungshilfeMenu.SetActive(false);
    }


}
