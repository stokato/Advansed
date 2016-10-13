using UnityEngine;
using System.Collections;

public class DrawWord : MonoBehaviour {

    public class Letters
    {
        public static Vector3[] A = new[]
        {
            new Vector3(-1, -1, 0),
            new Vector3(-1, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, -1, 0)
        };

        public static Vector3[] B = new[]
        {
            new Vector3(-1, -1, 0),
            new Vector3(-1, 1, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(-1, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, -1, 0),
            new Vector3(-1, -1, 0)
        };

        public static Vector3[] ToVectorArray(char c)
        {
            Vector3[] letter = null;
            
            switch (c)
            {
                case 'A':
                    letter = A;
                    break;

                case 'B':
                    letter = B;
                    break;
            }

            return letter;
        }
        public static void DrawWord(char c, float scale, Vector3 position, Color color)
        {
            Vector3[] lines = ToVectorArray(c);
            for (int i = 1; i < lines.Length; i++)
            {
                Vector3 start = (lines[i - 1] * scale);
                Vector3 end = (lines[i] * scale);

                Debug.DrawLine(start + position, end + position, color);
            }
        }
    }



    //public static void drawWord(string word, float scale, Vector3 position, Color color)
    //{
    //    string uLetters = word.ToUpper();
    //    char[] letters = uLetters.ToCharArray();
    //    if(letters.Length > 0)
    //    {
    //        for(int i = 0; i < letters.Length; i++)
    //        {
    //            float offset = (i * scale);
    //            Vector3 offsetPosition = new Vector3(offset + position.x, position.y, position.z);
    //            drawWord(letters[i], scale, offsetPosition, color);
    //        }
    //    }
    //}

    public static void Draw(string word, float scale, Vector3 position, Color color)
    {
        string uLetters = word.ToUpper();
        char[] letters = uLetters.ToCharArray();

        if (letters.Length > 0)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                float offset = (i * scale);
                Vector3 offsetPosition = new Vector3(offset + position.x, position.y, position.z);
                Letters.DrawWord(letters[i], scale, offsetPosition, color);
            }
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = Vector3.zero;
        Draw("words are being drawn", 2f, position, Color.black);
	}
}
