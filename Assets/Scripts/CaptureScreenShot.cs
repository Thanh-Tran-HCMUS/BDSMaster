using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityGoogleDrive;

public class CaptureScreenShot : MonoBehaviour
{
    public List<GameObject> allUI;
    //public RawImage ImageContainer;
    public RawImage DisplayQRDownloadURL;
    Texture2D currentImage;
    string imageFileName;

    //Google drive properties
    string fileID = "";
    string linkID = "";
    GoogleDriveFiles.CreateRequest request;
    GoogleDriveFiles.DownloadTextureRequest requestDownload;
    GoogleDriveFiles.GetRequest requestGet;

    IEnumerator ProcessImage()
    {
        foreach(GameObject ui in allUI)
        {
            ui.gameObject.SetActive(false);
        }
        yield return new WaitForEndOfFrame();
        ScreenCapture.CaptureScreenshot(imageFileName);
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.5f);
        foreach (GameObject ui in allUI)
        {
            ui.gameObject.SetActive(true);
        }
        LoadCaptureImage();
    }

    public void StartCapture()
    {
        imageFileName = DateTime.Now.ToString("yyyyMMddHHmmss");
        imageFileName += ".png";
        StartCoroutine("ProcessImage");
    }

    void LoadCaptureImage()
    {
        // read image and store in a byte array
        byte[] byteArray = File.ReadAllBytes(imageFileName);
        //create a texture and load byte array to it
        // Texture size does not matter 
        currentImage = new Texture2D(1, 1);
        currentImage.LoadImage(byteArray);
        // the size of the texture will be replaced by image size
        //bool isLoaded = sampleTexture.LoadImage(byteArray);
        //ImageContainer.texture = currentImage;

        var file = new UnityGoogleDrive.Data.File
        {
            Name = imageFileName,
            Content = byteArray
        };
        file.Parents = new List<string> { "1JcsQwTaAJBUVHYBCZoUainF7CFb_6Bup" };
        request = GoogleDriveFiles.Create(file);
        request.Fields = new List<string> { "id", "webViewLink"};
        request.Send().OnDone += SaveResult;

    }

    void SaveResult(UnityGoogleDrive.Data.File file)
    {
        fileID = file.Id;
        linkID = file.WebViewLink;
        //Debug.Log(linkID);
        DisplayQRDownloadURL.texture = QRUtils.GenerateQR(linkID);
    }


    public void DownloadImage()
    {
        requestDownload = GoogleDriveFiles.DownloadTexture(fileID, true);
        requestDownload.Send().OnDone += RenderImage;
    }

    void RenderImage(UnityGoogleDrive.Data.TextureFile textureFile)
    {
        Texture2D texture = textureFile.Texture;
        DisplayQRDownloadURL.texture = texture;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentImage = new Texture2D(1, 1);
        imageFileName = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
