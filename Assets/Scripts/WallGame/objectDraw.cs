using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectDraw : MonoBehaviour
{
    public MeshRenderer MeshRenderer;//Boyayacapýmýz Obje
    public Texture2D brush;// Fýrça Texture
    public Vector2Int textureArea;// x:1024 y:1024
    Texture2D texture;



    private float paintedArea, areaPiece;
    public static float percent;


    private void Start()
    {
        texture = new Texture2D(textureArea.x, textureArea.y, TextureFormat.ARGB32, false);
        MeshRenderer.material.mainTexture = texture;

        paintedArea = 0;
        areaPiece = textureArea.x * textureArea.y;
        percent = 0;

    }

    private void Update()
    {
        if (gameEnums.gameStatusCache == gameEnums.gameStatus.ENDGAME)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hitInfo;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    //Debug.Log(hitInfo.textureCoord);
                    Paint(hitInfo.textureCoord);
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (gameEnums.gameStatusCache == gameEnums.gameStatus.ENDGAME)
        {
            percentageController();
            percent = (paintedArea / areaPiece) * 100;
        }
    }



    private void Paint(Vector2 coordinate)
    {
        coordinate.x *= texture.width;
        coordinate.y *= texture.height;
        Color32[] textureC32 = texture.GetPixels32();
        Color32[] brushC32 = brush.GetPixels32();

        Vector2Int halfBrush = new Vector2Int(brush.width / 2, brush.height / 2);

        for (int x = 0; x < brush.width; x++)
        {
            int xPos = x - halfBrush.x + (int)coordinate.x;
            if (xPos < 0 || xPos >= texture.width)
            {
                continue;
            }
            for (int y = 0; y < brush.height; y++)
            {
                int yPos = y - halfBrush.y + (int)coordinate.y;
                if (yPos < 0 || yPos >= texture.height)
                {
                    continue;
                }


                if (brushC32[x + (y * brush.width)].a > 0f)
                {
                    int tPos = xPos + // X (U) pozisyonu
                        (texture.width * yPos);// Y (V) pozisyonu

                    if (brushC32[x + (y * brush.width)].a > textureC32[tPos].a)
                    {
                        //Debug.Log("kýrmýzý");
                        textureC32[tPos] = brushC32[x + (y * brush.width)];
                    }
                }
            }
        }

        texture.SetPixels32(textureC32);
        texture.Apply();
    }

    public void percentageController()
    {
        paintedArea = 0;
        Color32[] textureC32 = texture.GetPixels32();
        foreach (var item in textureC32)
        {
            if (item.r > 250f)
            {
                paintedArea += 1;
            }
        }
    }
}


