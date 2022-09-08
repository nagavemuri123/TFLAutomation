using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfl_AutomationTest.Interfaces
{
    public interface IBasePage
    {
        void NavigateToUrl();
        void CookieOverlay();
    }
}
