using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Domain.SecretariaContext
{
    public class DisciplinaNota
    {
        [Key]
        public int IdDisciplina { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal Nota { get; set; }
    }
}
