using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Proyecto.CRUD.Base.Infraestructura.Logging
{
    public static class ExceptionHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCurrentMethod()
        {
            var st = new StackTrace();
            var sf = st.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
