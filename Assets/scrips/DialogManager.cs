using System;
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

    [Header("Extra Resource")]
    [SerializeField]
    private TextAsset loadAsset;

    /// <summary>
    /// 台词表
    /// </summary>
    private List<List<string>> texts = new List<List<string>>();

    /// <summary>
    /// 章节数
    /// </summary>
    private int chapter;
    /// <summary>
    /// 语句序号
    /// </summary>
    private int phrase;

    public void Start() {
        LoadFile();
    }

    public void Update() {
        if (Input.GetKeyUp(KeyCode.Space) && this.DialogTexture.enabled) {
            NextPhrase();
        }
    }


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

    /// <summary>
    /// 从指定文件导入。
    /// 导入语句格式必须符合：
    /// [章节数][语句序号]\t[Text]
    /// 每行语句使用换行符分隔。
    /// 
    /// TextAsset 必须使用 UTF-8 编码。
    /// </summary>
    private void LoadFile() {
        List<string> chapters = new List<string>(loadAsset.text.Split('\n'));

        foreach (string sentence in chapters) {
            if (sentence.Trim().Equals(String.Empty)) {
                continue;
            }
            string cpCountPre = sentence.Split('\t')[0];

            try {
                int chapter = Convert.ToInt32(cpCountPre.Split('.')[0]);
                int phrase = Convert.ToInt32(cpCountPre.Split('.')[1]);

                if (this.texts.Count < chapter) {
                    for (int i = this.texts.Count; i < chapter; i++) {
                        this.texts.Add(new List<string>());

                        this.texts[i] = new List<string>();
                    }
                }
                if (this.texts[chapter - 1].Count < phrase) {
                    for (int i = this.texts[chapter - 1].Count; i < phrase; i++) {
                        this.texts[chapter - 1].Add(String.Empty);
                    }
                }
                this.texts[chapter - 1][phrase - 1] = sentence.Split('\t')[1];
            } catch (Exception) {
                continue;
            }
        }


        foreach (List<string> item in this.texts) {
            foreach (string text in item) {
                print(text);
            }
        }
    }
}
