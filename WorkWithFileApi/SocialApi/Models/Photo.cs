using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZwajApp.api.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string Url { get; set; }
    }
}