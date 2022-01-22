using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// DialogManager 类。
/// 控制 对话框 组件的相关行为。
/// </summary>
/// <author>LviatYi</author>
public class DialogManager : MonoBehaviour {
    [Header("UI componment")]
    [SerializeField]
    private Text DialogTexture;
    [SerializeField]
    private GameObject backgroundMask;

    /// <summary>
    /// 台词表
    /// </summary>
    private List<List<string>> texts;

    /// <summary>
    /// 章节数
    /// </summary>
    private int chapter;
    /// <summary>
    /// 语句序号
    /// </summary>
    private int phrase;


    /// <summary>
    /// 打开对话框。
    /// </summary>
    public void OpenDialog() {
        this.DialogTexture.enabled = true;
        this.backgroundMask.SetActive(true);
    }

    /// <summary>
    /// 打开对话框，并根据台词章节设定语句。
    /// </summary>
    /// <param name="chapter">章节数</param>
    /// <param name="phrase">语句序号</param>
    public void OpenDialog(int chapter, int phrase) {
        OpenDialog();
        SetText(chapter, phrase);
    }

    /// <summary>
    /// 关闭对话框。
    /// </summary>
    public void CloseDialog() {
        this.DialogTexture.enabled = false;
        this.backgroundMask.SetActive(false);
    }

    /// <summary>
    /// 设置对话框文本。
    /// </summary>
    /// <param name="text">文本</param>
    public void SetText(string text) {
        this.DialogTexture.text = text;
    }


    /// <summary>
    /// 根据台词章节设置对话框文本。
    /// </summary>
    /// <param name="chapter">章节数</param>
    /// <param name="phrase">语句序号</param>
    public void SetText(int chapter, int phrase) {
        SetText(this.texts[chapter][phrase]);
    }

    /// <summary>
    /// 进入下一句。
    /// </summary>
    public void NextPhrase() {
        if (texts[this.chapter].Count > ++phrase) {
            SetText(texts[this.chapter][this.phrase]);
        } else {
            this.phrase = 0;
            CloseDialog();
        }
    }

    /// <summary>
    /// 进入下一章。
    /// </summary>
    public void NextChapter() {
        if (texts.Count > ++chapter) {
            this.phrase = 0;
            SetText(texts[this.chapter][this.phrase]);
        } else {
            CloseDialog();
        }
    }
}
