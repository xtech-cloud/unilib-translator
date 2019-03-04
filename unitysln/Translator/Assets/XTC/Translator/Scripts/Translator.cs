/********************************************************************
     Copyright (c) XTechCloud
     All rights reserved.
*********************************************************************/

using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace XTC.Text
{
    public class Translator
    {
        public static Dictionary<string, Dictionary<string, string>> records = new Dictionary<string, Dictionary<string, string>>();

        public static string language = "en_US";

        public static void MergeFromJSON(string _json, bool _overwrite)
        {
            try
            {
                JSONArray root = JSON.Parse(_json).AsArray;
                foreach (JSONClass record in root)
                {
                    string text = record["text"].Value;
                    if (!records.ContainsKey(text))
                    {
                        records.Add(text, new Dictionary<string, string>());
                    }

                    Dictionary<string, string> pairs = records[text];

                    JSONClass jsonValues = record["values"].AsObject;
                    foreach (KeyValuePair<string, JSONNode> pair in jsonValues)
                    {
                        if (pairs.ContainsKey(pair.Key))
                        {
                            if (_overwrite)
                                pairs[pair.Key] = pair.Value.Value;
                        }
                        else
                        {
                            pairs[pair.Key] = pair.Value.Value;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.Message);
            }

        }

        public static void MergeFromResource(string _file, bool _overwrite)
        {
            TextAsset ta = Resources.Load<TextAsset>(_file);
            if (null == ta)
                throw new System.NullReferenceException(string.Format("load {0} form resources failed!", _file));
            MergeFromJSON(ta.text, _overwrite);
        }

        public static string Translate(string _record, bool _overwrite)
        {
            if (!records.ContainsKey(_record))
                return _record;

            Dictionary<string, string> values = records[_record];
            if (!values.ContainsKey(language))
                return _record;

            return values[language];
        }
    }//class
}//namespace

