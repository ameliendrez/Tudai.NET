using System;
using DAL;
using System.Collections.Generic;
using System.Linq;

namespace TUDAI
{
    public partial class AltaNoticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDdls();
                if (!string.IsNullOrEmpty(Request.QueryString.Get("isEdit")))
                {
                    int id = (int)Session["idGrupo"];

                    Noticia noticia = new Noticia()
                    {
                        Id = id

                    };        

                    using (NoticiaBusiness oNoticiaBussiness = new NoticiaBusiness())
                    {
                        noticia = Noticia.getFromDataRow(oNoticiaBussiness.GetNoticiaById(noticia).Tables[0].Rows[0]);
                    }

                    this.txt_titulo.Text = noticia.Titulo;
                    this.txt_cuerpo.Text = noticia.Cuerpo;
                    this.txt_autor.Text = noticia.Autor;
                    this.date_fecha.SelectedDate = noticia.Fecha;
                    this.ddl_categorias.SelectedIndex = (int)noticia.IdCategoria;

                    if (Request.QueryString.Get("isEdit").Equals("false"))
                    {
                        mostrar(false);                                               
                    }
   
                }                
            }
        }

        private void mostrar (bool val)
        {
            txt_titulo.Enabled = val;
            txt_autor.Enabled = val;
            txt_cuerpo.Enabled = val;
            ddl_categorias.Enabled = val;
            date_fecha.Enabled = val;
            btn_submit.Visible = val;
        }

        private void CargarDdls()
        {
            ddl_categorias.DataSource = new CategoriaBusiness().GetCategorias();            
            ddl_categorias.DataBind();   
        }

        protected void Publicar_Noticia(object sender, EventArgs e)
        {

            var oNoticia = new Noticia()
            {
                Id = (int)Session["idGrupo"],
                Titulo = txt_titulo.Text,
                Cuerpo = txt_cuerpo.Text,
                Fecha = date_fecha.SelectedDate,
                Autor = txt_autor.Text,
                IdCategoria = string.IsNullOrEmpty(ddl_categorias.SelectedValue) ? -1 : int.Parse(ddl_categorias.SelectedValue),
            };

            if (!string.IsNullOrEmpty(Request.QueryString.Get("isEdit")) && Request.QueryString.Get("isEdit").Equals("true"))
            {
                using (NoticiaBusiness n = new NoticiaBusiness())
                {
                    n.updateNoticia(oNoticia);
                }
                lbl_resultado.Text = "Noticia editada correctamente";


            }
            else
            {
                using (NoticiaBusiness n = new NoticiaBusiness())
                {
                    n.InsertNoticia(oNoticia);
                }
                lbl_resultado.Text = "Noticia publicada correctamente";

            }


        }
    }
}