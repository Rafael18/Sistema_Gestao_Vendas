
using SistemaVendas.Uteis;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SistemaVendas.Models
{
    public class LoginModel
    {
        public string? Id { get; set; } = "0";
        public string? Nome { get; set; }

        [Required(ErrorMessage ="Informe o e-mail.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O e-mail informado é invalido.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Informe a senha do usuário.")]
        public string Senha { get; set; }

        public bool validarLogin()
        {
            string sql = $"SELECT ID, NOME FROM VENDEDOR WHERE EMAIL='{Email}' AND SENHA='{Senha}'";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            if(dt.Rows.Count == 1 )
            {
                Id = dt.Rows[0]["ID"].ToString();
                Nome = dt.Rows[0]["NOME"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
