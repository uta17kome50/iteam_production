using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeManager : MonoBehaviour
{
    //フェード用のCanvasとImage
    private static Canvas fadeCanvas;
    private static Image fadeImage;

    //フェード用Imageの透明度
    private static float alphaColor = 0.0f;

    //フェードの時間
    private static float fadeTime = 2.0f;

    //遷移先のシーンの名前
    private static string nextScene = "GameScene";

    //フェードのフラグ
    public static bool isFadeIn = false;
    public static bool isFadeOut = false;

    //フェード用のCanvasとImageの生成
    static void Init()
    {
        //フェード用のCanvas生成
        GameObject FadeCanvasObject = new GameObject("CanvasFade");
        fadeCanvas = FadeCanvasObject.AddComponent<Canvas>();
        FadeCanvasObject.AddComponent<GraphicRaycaster>();
        fadeCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        FadeCanvasObject.AddComponent<FadeManager>();

        //最前面に画像が表示されるようにOrder in Layerを設定
        fadeCanvas.sortingOrder = 100;

        //フェード用のImage生成
        fadeImage = new GameObject("FadeImage").AddComponent<Image>();
        fadeImage.transform.SetParent(fadeCanvas.transform, false);
        fadeImage.rectTransform.anchoredPosition = Vector3.zero;

        //Imageのサイズ（指定サイズ1920＊1080）
        fadeImage.rectTransform.sizeDelta = new Vector2(1920, 1080);
    }

    //フェードイン開始
    public static void FadeIn()
    {
        //既にフェードされていなければフェードイン
        if (fadeImage == null)
        {
            Init();
        }
        fadeImage.color = Color.black;
        isFadeIn = true;
    }

    //フェードアウト開始
    public static void FadeOut(string SceneName)
    {
        //既にフェードされていなければフェードアウト
        if (fadeImage == null)
        {
            Init();
        }
        nextScene = SceneName;
        fadeImage.color = Color.clear;
        fadeCanvas.enabled = true;
        isFadeOut = true;
    }

    void Update()
    {
        //フラグ有効なら毎フレーム画像の透明度を調節
        if (isFadeIn)
        {
            //透明度の処理
            alphaColor -= Time.deltaTime / fadeTime;

            //透明度が0(画像が透明)になった時
            if (alphaColor <= 0.0f)
            {
                isFadeIn = false;
                alphaColor = 0.0f;
                fadeCanvas.enabled = false;
            }

            //フェード用Imageの色・透明度設定
            fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alphaColor);

        }
        else if (isFadeOut)
        {
            //透明度の処理
            alphaColor += Time.deltaTime / fadeTime;

            //透明度が1(画像が完全無透明)になった時
            if (alphaColor >= 1.0f)
            {
                isFadeOut = false;
                alphaColor = 1.0f;

                //次のシーンへ
                SceneManager.LoadScene(nextScene);
            }

            //フェード用Imageの色・透明度設定
            fadeImage.color = new Color(0.0f, 0.0f, 0.0f, alphaColor);
        }
    }
}
