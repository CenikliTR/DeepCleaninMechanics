using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Cleaning : MonoSingleton<Dirt_Cleaning>
{

    [SerializeField] private Camera _camera;

    [SerializeField] private Texture2D _dirtMaskBase;
    [SerializeField] private Texture2D _brush;

    [SerializeField] private Material _material;

    private Texture2D _templateDirtMask;
    private Vector2Int _lastPaintPixelPosition;
    [SerializeField] private float dirtAmountTotal;
    [SerializeField] private float dirtAmount;
    public bool clean = false;
    private void Awake()
    {
        CreateTexture();
        dirtAmountTotal = 0f;
        for (int x = 0; x < _dirtMaskBase.width; x++)
        {
            for (int y = 0; y < _dirtMaskBase.height; y++)
            {
                dirtAmountTotal += _dirtMaskBase.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;
    }

    public void CleanDirt()
    {
        
        if (GameManager.Instance.mode == GameManager.Mode.WaterVacum && ControllSystem.Instance.isClicked)
        {

            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Vector2 textureCoord = hit.textureCoord;

                int pixelX = (int)(textureCoord.x * _templateDirtMask.width);
                int pixelY = (int)(textureCoord.y * _templateDirtMask.height);


             
                Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);
                for (int x = 0; x < _brush.width; x++)
                {
                    for (int y = 0; y < _brush.height; y++)
                    {
                        Color pixelDirt = _brush.GetPixel(x, y);
                        Color pixelDirtMask = _templateDirtMask.GetPixel(pixelX + x, pixelY + y);
                        float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                        dirtAmount -= removedAmount;
                        if (dirtAmount / 10000 <= 7)
                        {
                            clean = true;
                            break;
                        }
                        _lastPaintPixelPosition = paintPixelPosition;
                        _templateDirtMask.SetPixel(pixelX + x,
                            pixelY + y,
                            new Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                    }
                }

                _templateDirtMask.Apply();
            }
        }
    }
    private float GetDirtAmount()
    {
        return this.dirtAmount / dirtAmountTotal;
    }
    private void CreateTexture()
    {
        _templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        _templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        _templateDirtMask.Apply();

        _material.SetTexture("DirtTexture", _templateDirtMask);
    }
}
