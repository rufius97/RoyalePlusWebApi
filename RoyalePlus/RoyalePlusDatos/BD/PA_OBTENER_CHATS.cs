//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoyalePlusDatos.BD
{
    using System;
    
    public partial class PA_OBTENER_CHATS
    {
        public int ID_CHAT { get; set; }
        public string ULTIMO_MENSAJE { get; set; }
        public string ULTIMO_EN_HABLAR { get; set; }
        public Nullable<System.DateTime> ULTIMO_TIEMPO { get; set; }
        public string NOMBRE_CHAT { get; set; }
        public string TIPO { get; set; }
        public Nullable<int> MENSAJES_SIN_LEER { get; set; }
        public Nullable<int> ID_CONTRARIO { get; set; }
    }
}
