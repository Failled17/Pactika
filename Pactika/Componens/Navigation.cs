using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Controls;

namespace Pactika.Componens
{
    internal class Navigation
    {
        public static Page<Nav> navs = new Page<Nav>();
        public static MainWindow main;
        public static User AutoPage;
        public static bool IsUser;
        public static void NextPage(Nav nav)
    }
}
