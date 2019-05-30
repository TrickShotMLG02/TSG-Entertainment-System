using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class reader : MonoBehaviour
{
    public bool BootLoop;
    public bool finnished = true;
    bool skip;
    public bool LoadScene;

    public string[] linesInFile;
    string TextLine1;
    string TextLine2;
    string TextLine3;
    string TextLine4;
    string TextLine5;
    string TextLine6;
    string TextLine7;
    string TextLine8;
    string TextLine9;
    string TextLine10;
    string TextLine11;
    string TextLine12;
    string TextLine13;
    string TextLine14;
    string TextLine15;

    bool _1;
    bool _2;
    bool _3;
    bool _4;
    bool _5;
    bool _6;
    bool _7;
    bool _8;
    bool _9;
    bool _10;
    bool _11;
    bool _12;
    bool _13;
    bool _14;
    bool _15;

    public TextAsset TextFile;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReadFile());
    }

    public IEnumerator ReadFile()
    {
        if (skip == false)
        {
            yield return new WaitForSeconds(0.2f);
            linesInFile = TextFile.text.Split('\n');

            TextLine1 = linesInFile[0];
            TextLine2 = linesInFile[1];
            TextLine3 = linesInFile[2];
            TextLine4 = linesInFile[3];
            TextLine5 = linesInFile[4];
            TextLine6 = linesInFile[5];
            TextLine7 = linesInFile[6];
            TextLine8 = linesInFile[7];
            TextLine9 = linesInFile[8];
            TextLine10 = linesInFile[9];
            TextLine11 = linesInFile[10];
            TextLine12 = linesInFile[11];
            TextLine13 = linesInFile[12];
            TextLine14 = linesInFile[13];
            TextLine15 = linesInFile[14];
            finnished = false;
            skip = true;
        }
        

        foreach (string line in linesInFile)
        {
            
            yield return new WaitForSeconds(0.1f);
            if (_1 == false)
            {
                _1 = true;
                text.text = TextLine1;
            }

            yield return new WaitForSeconds(0.1f);
            if (_2 == false)
            {
                _2 = true;
                text.text = TextLine1 + "\n" + TextLine2;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_3 == false)
            {
                _3 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_4 == false)
            {
                _4 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_5 == false)
            {
                _5 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_6 == false)
            {
                _6 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_7 == false)
            {
                _7 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_8 == false)
            {
                _8 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_9 == false)
            {
                _9 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8 + "\n" + TextLine9;
            }

            yield return new WaitForSeconds(0.001f);
            if (_10 == false)
            {
                _10 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8 + "\n" + TextLine9 + "\n" + TextLine10;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_11 == false)
            {
                _11 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8 + "\n" + TextLine9 + "\n" + TextLine10 + "\n" + TextLine11;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_12 == false)
            {
                _12 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8 + "\n" + TextLine9 + "\n" + TextLine10 + "\n" + TextLine11 + "\n" + TextLine12;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_13 == false)
            {
                _13 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8 + "\n" + TextLine9 + "\n" + TextLine10 + "\n" + TextLine11 + "\n" + TextLine12 + "\n" + TextLine13;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_14 == false)
            {
                _14 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8 + "\n" + TextLine9 + "\n" + TextLine10 + "\n" + TextLine11 + "\n" + TextLine12 + "\n" + TextLine13 + "\n" + TextLine14;
            }

            yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));
            if (_15 == false)
            {
                _15 = true;
                text.text = TextLine1 + "\n" + TextLine2 + "\n" + TextLine3 + "\n" + TextLine4 + "\n" + TextLine5 + "\n" + TextLine6 + "\n" + TextLine7 + "\n" + TextLine8 + "\n" + TextLine9 + "\n" + TextLine10 + "\n" + TextLine11 + "\n" + TextLine12 + "\n" + TextLine13 + "\n" + TextLine14 + "\n" + TextLine15;
                finnished = true;

                if (BootLoop == true)
                {
                    Debug.Log("BootLoop true");
                    
                }
                else if (LoadScene == true)
                {
                    SceneManager.LoadScene("SplashScreen");
                }
            }           
        }
    }


    // Update is called once per frame
    void Update()
    {

        if (BootLoop == true && finnished == true)
        {
            text.text = "";
            StartCoroutine(ReadFile());           
        }
    }
}
