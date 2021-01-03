using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace CBL
{
    public class LoadAndSave<T>
    {
        public string Path { get; set; }
        public LoadAndSave(string path)
        {
            Path = path;
        }
        
        public List<T> Load()
        {
            var fileExist = File.Exists(Path);
            if (!fileExist)
            {
                File.CreateText(Path).Dispose();
                return new List<T>();
            }
            using (var reader = File.OpenText(Path))
            {
                var filetext = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(filetext);
            }
        }
        public void Save(List<T> ts)
        {
            using(StreamWriter str = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(ts);
                str.Write(output);
            }
        }

    }
}
