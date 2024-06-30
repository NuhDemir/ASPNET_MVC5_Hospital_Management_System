
namespace MVC5_HOSPITAL_MANAGEMENT_SYSTEMS
{ public class Toastr
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public ToastrType Type { get; set; }

        public Toastr()
        {

        }

        public Toastr(string message, string title = "Information", ToastrType type = ToastrType.Info)
        {
            this.Message = message;
            this.Title = title;
        }
    }
}