using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPDV___Lanchonete
{
    class MP2032
    {

        [DllImport("MP2032")]
        public static extern int ComandoTX(string comando, int tCOmando);

        [DllImport("MP2032")]
        public static extern int IniciaPorta(string porta);

        [DllImport("MP2032")]
        public static extern int FechaPorta();

        [DllImport("MP2032")]
        public static extern int ConfiguraModeloImpressora(int iModelo);

        [DllImport("MP2032")]
        public static extern int AcionaGuilhotina(int guilhotina);

        [DllImport("MP2032")]
        public static extern int FormataTX(string texto, int tipoLetra, int italico, int sublinhado, int expandido, int enfatizado);

    }
}
