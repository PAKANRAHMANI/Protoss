using System.Collections.Generic;

namespace Protoss.Restful
{
    public interface IResource
    {
        object State { get; set; }
        List<Link> Links { get; set; }
        List<EmbeddedResource> EmbeddedResources { get; set; }
    }
}