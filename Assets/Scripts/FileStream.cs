using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class FileStream : MonoBehaviour {

	// Use this for initialization
	void Start () {
        System.IO.FileStream file = null;
        FileInfo fileInfo = null;

        try
        {
            fileInfo = new FileInfo("D:\\file.txt");
            file = fileInfo.OpenWrite();

            for(int i = 0; i < 255; i++)
            {
                file.WriteByte((byte)i);
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
