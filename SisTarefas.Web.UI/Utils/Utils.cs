using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisTarefas.Web.UI
{
    public static class Utils
    {
        public static bool ValidaParams(dynamic[] parametros)
        {
            foreach (dynamic item in parametros)
            {
                if (item == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}