using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/bios.txt";

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    // Update is called once per frame
    void Update()
    {

    }


}
