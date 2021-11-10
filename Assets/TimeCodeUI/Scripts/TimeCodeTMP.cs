using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TimeCodeUI
{
    [ExecuteAlways]
    
    public class TimeCodeTMP : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_textMeshProUGUI;
        [SerializeField] private PlayableDirector m_PlayableDirector;
        private StringBuilder stringBuilder;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (stringBuilder == null) stringBuilder = new StringBuilder();
            if (m_PlayableDirector != null)
            {
                m_textMeshProUGUI.autoSizeTextContainer = true;
                stringBuilder.Clear();
                var timelineAsset = m_PlayableDirector.playableAsset as TimelineAsset;
                var fps = (float)timelineAsset.editorSettings.frameRate;
                var dateTime = new TimeSpan(0,0,(int)m_PlayableDirector.time);
                stringBuilder.Append(dateTime.ToString(@"hh\:mm\:ss"));
                stringBuilder.Append(" ");
                stringBuilder.Append((Mathf.CeilToInt(fps * (float)m_PlayableDirector.time)));
                stringBuilder.Append("f");
                if (m_textMeshProUGUI != null) m_textMeshProUGUI.text = stringBuilder.ToString();


            }
        }
    }
}