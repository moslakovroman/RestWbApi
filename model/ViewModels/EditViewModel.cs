namespace model.ViewModels
{
    public class EditViewModel : BaseModel
    {
        
        public int EditUserId { get; set; }
        public string EditTitle { get; set; }
        public string EditBody { get; set; }
    }
}