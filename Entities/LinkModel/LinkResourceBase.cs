namespace Entities.LinkModel
{
    public class LinkResourceBase        // Bir kaynağa ait linklerin organizasyonunu yapacak.
    {
        public LinkResourceBase()
        {
            
        }
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
