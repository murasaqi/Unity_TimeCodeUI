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
    
    public class TimelineTC : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_textMeshProUGUI;
        [SerializeField] private PlayableDirector m_PlayableDirector;
        [SerializeField] private string format = "HH:mm:ss";
        [SerializeField] private bool viewFrame = false;
        [SerializeField] private bool viewEnableTrackNames = false;
        private StringBuilder _stringBuilder;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (_stringBuilder == null) _stringBuilder = new StringBuilder();
            if (m_PlayableDirector != null)
            {
                m_textMeshProUGUI.autoSizeTextContainer = true;
                _stringBuilder.Clear();
                var timelineAsset = m_PlayableDirector.playableAsset as TimelineAsset;
                if (viewEnableTrackNames)
                {
                    
                    var tracks = timelineAsset.GetOutputTracks();

                    foreach (var t in tracks)
                    {
                        if (!t.muted) _stringBuilder.AppendLine(t.name);
                    }
                }
                var fps = (float)timelineAsset.editorSettings.frameRate;
                var timeSpan = new TimeSpan(0,0,(int)m_PlayableDirector.time);
                var dateTime = new DateTime(timeSpan.Ticks);
                _stringBuilder.Append(dateTime.ToString(format));
                if (viewFrame)
                {
                    _stringBuilder.Append(" ");
                    _stringBuilder.Append((Mathf.CeilToInt(fps * (float)m_PlayableDirector.time)));
                    _stringBuilder.Append("f");     
                }
                if (m_textMeshProUGUI != null) m_textMeshProUGUI.text = _stringBuilder.ToString();


            }
        }
    }
}