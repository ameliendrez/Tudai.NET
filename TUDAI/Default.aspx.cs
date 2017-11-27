using System;
using DAL;

namespace TUDAI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvNoticias.DataSource = new NoticiaBusiness().GetNoticias();
            gvNoticias.DataBind();
        }


        protected void gvNoticias_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
          
                int id = (int)gvNoticias.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                Session.Add("idGrupo",id);

                Noticia oNoticia = new Noticia();
                oNoticia.Id = id;

                switch (e.CommandName)
                {
                    case "editar":
                        Response.Redirect("alta_noticia.aspx?isEdit=true", false);
                        break;
                    case "mostrar":
                        Response.Redirect("alta_noticia.aspx?isEdit=false", false);
                        break;
                    default:
                        break;
                }


            
        }
    }
}