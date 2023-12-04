using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MonitorDeEstrés_AESM.VistaModelo
{
    public class VMpaginaPrincipal : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        string _FrecuenciaCardiaca;
        string _HorasSueno;
        string _NivelEstres;
        string _Imagen;

        #endregion
        #region CONSTRUCTOR
        public VMpaginaPrincipal(INavigation navigation)
        {
            Navigation = navigation;

        }
        #endregion
        #region OBJETOS
        public string Imagen
        {
            get { return _Imagen; }
            set { SetValue(ref _Imagen, value); }
        }
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string FrecuenciaCardiaca
        {
            get { return _FrecuenciaCardiaca; }
            set { SetValue(ref _FrecuenciaCardiaca, value); }
        } public string HorasSueno
        {
            get { return _HorasSueno; }
            set { SetValue(ref _HorasSueno, value); }
        }
        public string NivelEstress
        {
            get { return _NivelEstres; }
            set { SetValue(ref _NivelEstres, value);}
        }

        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void CalcularEstres()
        {
            double frecuencia = 0;
            double horas = 0;
            double nivelEstres = 0;
            bool imagen = true;

            frecuencia = double.Parse(FrecuenciaCardiaca);
            horas = double.Parse(HorasSueno);

            nivelEstres = (frecuencia/100)+(0.2*(8-horas));
            

            if (nivelEstres <= 1.4)
            {
                NivelEstress = "Estrés Bajo " + nivelEstres;
            }
            else if (nivelEstres >= 1.5 && nivelEstres <= 2.0 )
            {
                NivelEstress = "Estrés Moderado " + nivelEstres;
            }
            else
            {
                NivelEstress = "Alto Estrés " + nivelEstres;
                Imagen = imagen.ToString();
            }
        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncomand => new Command(async () => await ProcesoAsyncrono());
        public ICommand Calcularestrescommand => new Command(CalcularEstres);
        #endregion
    }
}
