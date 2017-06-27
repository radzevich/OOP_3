using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using PluginInterface;
using Serialization.Configs;

namespace Serialization.Services
{
    class PluginManager
    {
        private readonly Type _type;
        private readonly string _path;

        public Dictionary<string, string> GetNewClass()
        {
            if (_type.GetInterfaces().Contains(typeof(IHierarchyPlugin)))
            {
                var plugin = Activator.CreateInstance(_type) as IHierarchyPlugin;

                if (IsValid(plugin.PublicKey))
                {
                    AddToConfig();
                    return plugin.Content;
                }
            }
            return null;
        }

        public List<string> GetNewContent()
        {
            if (_type.GetInterfaces().Contains(typeof(IContentPlugin)))
            {
                var plugin = Activator.CreateInstance(_type) as IContentPlugin;

                if (IsValid(plugin.PublicKey))
                {
                    AddToConfig();
                    return plugin.Content;
                }
            }
            return null; 
        }

        private void AddToConfig()
        {
            var pluginConfig = new PluginConfig();

            pluginConfig.Add(_type.Name, _path);
        }

        private bool IsValid(string path)
        {
            return true;
        }

        public PluginManager(string pluginPath)
        {
            _type = Assembly.LoadFrom(pluginPath).GetTypes().First(); ;
            _path = pluginPath;
        }
    }
}
