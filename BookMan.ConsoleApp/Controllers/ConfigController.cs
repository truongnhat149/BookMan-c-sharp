using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMan.ConsoleApp.Controllers
{
    using Framework;
    internal class ConfigController : ControllerBase
    {
        private Config _config = Config.Instance;
        private string da;
        private string file;

        public void ConfigPromptText(string text)
        {
            _config.PromptText = text;
            Success("The command prompt will change next time");
        }

        public void ConfigPromptColor(string text)
        {
            if  (Enum.TryParse(text, true, out ConsoleColor color))
            {
                _config.PromptColor = color;
                Success("The command prompt color will change next time");
            }
        }

        public void CurrentDataAccess()
        {
             da = _config.DataAccess;
             file = _config.DataFile;
            Inform($"Current data access engine {da} Current data file : {file}");
        }

        public void ConfigDataAccess()
        {
            _config.DataAccess = da;
            _config.DataFile = file;
            Success("The change will be available next time");
        }
    }
}
