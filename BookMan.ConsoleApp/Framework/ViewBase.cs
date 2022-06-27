﻿using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public abstract class ViewBase
    {
        protected Router router = Router.Instance;
        public ViewBase() { }
        public abstract void Render();
    }
    public abstract class ViewBase<T> : ViewBase 
    {
        protected T Model;
        public ViewBase(T model) => Model = model;

        public virtual void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!");
        }
    }
}
