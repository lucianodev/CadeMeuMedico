using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    [MetadataType(typeof(MedicoMetadado))]
    public partial class Medicos {}

    public class MedicoMetadado
    {
        [Required (ErrorMessage ="Obrigatório informar o CRM.")]
        [StringLength(30, ErrorMessage ="O CRM deve possuir no máximo 30 caracteres.")]
        public string CRM { get; set; }

        [Required (ErrorMessage ="Preencha o Nome.")]
        [StringLength(80, ErrorMessage ="O nome deve possuir no máximo 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O end. é obrigatório.")]
        [StringLength (100, ErrorMessage ="Máx 100.")]
        public string Endereco { get; set; }

        [Required (ErrorMessage ="Bairro obrigatório.")]
        [StringLength (60, ErrorMessage ="Máx 60.")]
        public string Bairro { get; set; }

        [Required (ErrorMessage ="Email obrigatório.")]
        [StringLength (100, ErrorMessage ="Máximo 100.")]
        public string Email { get; set; }

        [Required (ErrorMessage ="Obrigatório informar se atende convenio.")]
        public bool AtendePorConvenio { get; set; }

        [Required (ErrorMessage ="Obrigatório informar se tem clínica.")]
        public bool TemClinica { get; set; }

        [StringLength (80, ErrorMessage ="Máximo 80.")]
        public string WebsiteBlog { get; set; }

        [Required (ErrorMessage ="Informe a cidade.")]
        public int IDCidade { get; set; }

        [Required (ErrorMessage ="Informe a especialidade.")]
        public int IDEspecialidade { get; set; }
    }
}