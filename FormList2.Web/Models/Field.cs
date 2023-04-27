namespace FormList2.Web.Models
{
    public class Field
    {
        public Field()
        {
            Forms = new HashSet<Form>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public int? Age { get; set; }

        public ICollection<Form> Forms { get; set; }
    }
}
