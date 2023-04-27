namespace FormList2.Web.Models
{
    public class FormRepository
    {


        private static List<Form> _forms = new List<Form>()
        {

        };

        public List<Form> Forms() => _forms;

        public void Create(Form newForm) => _forms.Add(newForm);

        public void Edit(Form newForm) => _forms.Add(newForm);

        public List<Form> GetAll() => _forms;

    }
}
