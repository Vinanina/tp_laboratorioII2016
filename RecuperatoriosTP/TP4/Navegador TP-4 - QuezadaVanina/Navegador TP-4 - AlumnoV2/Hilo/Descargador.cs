using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }



        public delegate void EventProgreso(int progress);
        public event EventProgreso Progreso;
        public delegate void EventCompletado(string url);
        public event EventCompletado Completo;

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }            
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

            this.Progreso(e.ProgressPercentage);

        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                this.html = (string)e.Result;
            }
            this.Completo(this.html);

        }

       // public DownloadProgressChangedEventHandler DownloadProgressCallback { get; set; }
    }
}
