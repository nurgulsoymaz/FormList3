namespace FormList2.Web.Models
{
    public class Form
    {

        public int Id { get; set; }
        public string FormName { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public int CreatedBy { get; set; }

        public int FieldId { get; set; }

        public virtual Field Field { get; set; }
    }
}
