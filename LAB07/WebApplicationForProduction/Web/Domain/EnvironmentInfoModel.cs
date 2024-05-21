using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Web.Domain
{
    [Table("EnvironmentInfo")]
    [PrimaryKey("Value")]
    public class EnvironmentInfoModel
    {

        [NotNull]
        public string Value { get; set; }
    }
}
